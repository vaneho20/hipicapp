using Hipicapp.Model.Authentication;
using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Repository.Event;
using Hipicapp.Repository.Participant;
using Hipicapp.Service.Account;
using Hipicapp.Service.Event;
using Hipicapp.Service.Mail.Impl;
using Hipicapp.Service.Mail.Models;
using Hipicapp.Service.Util;
using Hipicapp.Services.File;
using Hipicapp.Utils.Pager;
using Resources;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hipicapp.Service.Participant
{
    [Service]
    public class AthleteService : IAthleteService
    {
        [Autowired]
        private IAthleteRepository AthleteRepository { get; set; }

        [Autowired]
        public ICompetitionCategoryRepository CompetitionCategoryRepository { get; set; }

        [Autowired]
        public ICompetitionRepository CompetitionRepository { get; set; }

        [Autowired]
        private IEnrollmentRepository EnrollmentRepository { get; set; }

        [Autowired]
        private IHorseRepository HorseRepository { get; set; }

        [Autowired]
        public ISpecialtyRepository SpecialtyRepository { get; set; }

        [Autowired]
        private IFileService FileService { get; set; }

        [Autowired]
        private IUserService UserService { get; set; }

        [Autowired]
        private IAlreadyEnrolledPolicy AlreadyEnrolledPolicy { get; set; }

        [Autowired]
        private IAvailableCompetitionCategoryPolicy AvailableCompetitionCategoryPolicy { get; set; }

        [Autowired]
        private ICompetitionExpiredPolicy CompetitionExpiredPolicy { get; set; }

        [Autowired]
        private IEnrollmentExpiredPolicy EnrollmentExpiredPolicy { get; set; }

        [Autowired]
        private IMinimumAgeOfHorseUnsurpassedPolicy MinimumAgeOfHorseUnsurpassedPolicy { get; set; }

        [Autowired]
        private ISameCompetitionCategoryPolicy SameCompetitionCategoryPolicy { get; set; }

        [Transaction(ReadOnly = true)]
        public Page<Athlete> Paginated(AthleteFindFilter filter, PageRequest pageRequest)
        {
            return this.AthleteRepository.Paginated(AthletePredicates.ValueOf(filter, this.AthleteRepository.GetAllQueryable()), pageRequest);
        }

        [Transaction(ReadOnly = true)]
        public Athlete Get(long? id)
        {
            return this.AthleteRepository.Get(id);
        }

        [Transaction(ReadOnly = true)]
        public Athlete GetByUserId(long? userId)
        {
            return this.AthleteRepository.GetByUserId(userId);
        }

        [Transaction(ReadOnly = true)]
        public string GetFullNameByUserId(long? userId)
        {
            return this.AthleteRepository.GetByUserId(userId).FullName;
        }

        [Transaction]
        public Athlete Save(Athlete athlete)
        {
            athlete.BirthDate = athlete.BirthDate.Value.Date;
            var year = athlete.BirthDate.Value.Year;
            athlete.Id = null;
            athlete.User.Password = null;
            athlete.User.OldPassword = null;
            athlete.User.Roles = new HashSet<Rol>() { Rol.ATHLETE };
            athlete.User.RegistrationDate = DateTime.Now;
            athlete.User = this.UserService.Save(athlete.User);
            athlete.UserId = athlete.User.Id;
            athlete.Category = this.CompetitionCategoryRepository.GetAllQueryable()
                .FirstOrDefault(x => (x.Later == true && year >= x.InitialYear)
                    || (year >= x.InitialYear && year <= x.FinalYear)
                    || (x.Previous == true && year <= x.FinalYear));
            this.AvailableCompetitionCategoryPolicy.CheckSatisfiedBy(athlete.Category);
            athlete.CategoryId = athlete.Category.Id;
            athlete.Specialty = this.SpecialtyRepository.Get(athlete.SpecialtyId);
            athlete.SpecialtyId = athlete.Specialty.Id;
            athlete.Id = this.AthleteRepository.Save(athlete);
            MailUtil.SendMessage<CreatedAccountEmailModel>(new CreatedAccountMailMessage(MailMessages.CreatedAccountSubject, athlete));
            return athlete;
        }

        [Transaction]
        public Athlete Update(Athlete athlete)
        {
            var model = this.AthleteRepository.Get(athlete.Id);
            model.Name = athlete.Name;
            model.Surnames = athlete.Surnames;
            model.Dni = athlete.Dni;
            if (model.BirthDate != athlete.BirthDate)
            {
                model.BirthDate = athlete.BirthDate;
                var year = athlete.BirthDate.Value.Year;
                model.Category = this.CompetitionCategoryRepository.GetAllQueryable()
                    .FirstOrDefault(x => (x.Later == true && year >= x.InitialYear)
                        || (year >= x.InitialYear && year <= x.FinalYear)
                        || (x.Previous == true && year <= x.FinalYear));
                this.AvailableCompetitionCategoryPolicy.CheckSatisfiedBy(model.Category);
                model.CategoryId = model.Category.Id;
            }
            model.Gender = athlete.Gender;
            model.Weight = athlete.Weight;
            model.Federation = athlete.Federation;
            model.ZipCode = athlete.ZipCode;
            model.PlaceId = athlete.PlaceId;
            model.Specialty = this.SpecialtyRepository.Get(athlete.SpecialtyId);
            model.SpecialtyId = model.Specialty.Id;
            this.AthleteRepository.Update(model);
            return model;
        }

        [Transaction]
        public Athlete Delete(Athlete athlete)
        {
            this.AthleteRepository.Delete(this.AthleteRepository.Get(athlete.Id));
            return athlete;
        }

        [Transaction]
        public EnrollmentId Inscription(EnrollmentId id)
        {
            var horse = this.HorseRepository.Get(id.HorseId);
            var competition = this.CompetitionRepository.Get(id.CompetitionId);
            this.AlreadyEnrolledPolicy.CheckSatisfiedBy(competition, horse);

            var enroll = this.EnrollmentRepository.GetAllQueryable().FirstOrDefault(x => x.Id.CompetitionId == competition.Id && x.Horse.AthleteId == horse.AthleteId);
            if (enroll != null)
            {
                this.EnrollmentRepository.Delete(enroll);
            }
            this.EnrollmentExpiredPolicy.CheckSatisfiedBy(competition);
            this.CompetitionExpiredPolicy.CheckSatisfiedBy(competition);
            this.SameCompetitionCategoryPolicy.CheckSatisfiedBy(horse.Athlete.Category, competition.Category);
            this.MinimumAgeOfHorseUnsurpassedPolicy.CheckSatisfiedBy(horse, competition.Specialty);
            this.EnrollmentRepository.Save(new Enrollment()
            {
                Id = id,
                EnrollmentDate = DateTime.Now
            });
            return id;
        }

        [Transaction(ReadOnly = true)]
        public bool? HasEnrolled(long? competitionId, long? userId)
        {
            return this.EnrollmentRepository.GetAllQueryable().Any(x => x.Id.CompetitionId == competitionId && x.Horse.Athlete.UserId == userId);
        }

        [Transaction]
        public FileInfo Upload(Athlete athlete, string name, string mimeType, byte[] bytes)
        {
            long? previousPhotoId = athlete.PhotoId;

            FileInfo newPhotoFileInfo = this.FileService.Save(name, mimeType, bytes);

            athlete.PhotoId = newPhotoFileInfo.Id;
            athlete.Photo = newPhotoFileInfo;

            this.AthleteRepository.Update(athlete);

            if (previousPhotoId != null)
            {
                this.FileService.Delete(previousPhotoId);
            }

            return newPhotoFileInfo;
        }
    }
}