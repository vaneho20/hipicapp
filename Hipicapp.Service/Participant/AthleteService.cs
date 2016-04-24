using Hipicapp.Model.Authentication;
using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Repository.Event;
using Hipicapp.Repository.Participant;
using Hipicapp.Service.Account;
using Hipicapp.Services.File;
using Hipicapp.Utils.Pager;
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
        private IEnrollmentRepository EnrollmentRepository { get; set; }

        [Autowired]
        private IFileService FileService { get; set; }

        [Autowired]
        private IUserService UserService { get; set; }

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

        [Transaction]
        public Athlete Save(Athlete athlete)
        {
            athlete.BirthDate = athlete.BirthDate.Value.Date;
            var year = athlete.BirthDate.Value.Year;
            athlete.Id = null;
            athlete.User.Password = null;
            athlete.User.OldPassword = null;
            athlete.User.Roles = new HashSet<Rol>() { Rol.ATHLETE };
            athlete.User = this.UserService.Save(athlete.User);
            athlete.UserId = athlete.User.Id;
            athlete.Category = this.CompetitionCategoryRepository.GetAllQueryable()
                .FirstOrDefault(x => (x.Later == true && year >= x.InitialYear)
                    || (year >= x.InitialYear && year <= x.FinalYear)
                    || (x.Previous == true && year <= x.FinalYear));
            athlete.CategoryId = athlete.Category.Id;
            athlete.Id = this.AthleteRepository.Save(athlete);
            return athlete;
        }

        [Transaction]
        public Athlete Update(Athlete athlete)
        {
            var model = this.AthleteRepository.Get(athlete.Id);
            model.Name = athlete.Name;
            model.Surnames = athlete.Surnames;
            model.Dni = athlete.Dni;
            model.BirthDate = athlete.BirthDate;
            model.Gender = athlete.Gender;
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
            if (this.EnrollmentRepository.GetAllQueryable().Count(x => x.Id.CompetitionId == id.CompetitionId && x.Id.HorseId == id.HorseId) <= 0)
            {
                this.EnrollmentRepository.Save(new Enrollment()
                {
                    Id = id,
                    EnrollmentDate = DateTime.Now
                });
            }
            else
            {
            }
            return id;
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