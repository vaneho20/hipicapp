using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Repository.Event;
using Hipicapp.Repository.Participant;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hipicapp.Service.Event
{
    [Service]
    public class CompetitionService : ICompetitionService
    {
        [Autowired]
        private ICompetitionRepository CompetitionRepository { get; set; }

        [Autowired]
        private IEnrollmentRepository EnrollmentRepository { get; set; }

        [Autowired]
        private ISeminaryRepository SeminaryRepository { get; set; }

        [Autowired]
        private IScoreRepository ScoreRepository { get; set; }

        [Autowired]
        private IWeightAthleteSaddleExceededPolicy WeightAthleteSaddleExceededPolicy { get; set; }

        [Transaction(ReadOnly = true)]
        public Page<Competition> Paginated(CompetitionFindFilter filter, PageRequest pageRequest)
        {
            return this.CompetitionRepository.Paginated(CompetitionPredicates.ValueOf(filter, this.CompetitionRepository.GetAllQueryable()), pageRequest);
        }

        [Transaction(ReadOnly = true)]
        public Competition Get(long? id)
        {
            return this.CompetitionRepository.Get(id);
        }

        [Transaction]
        public Competition Save(Competition competition)
        {
            CompetitionRepository.Save(competition);
            return competition;
        }

        [Transaction]
        public Competition Update(Competition competition)
        {
            var model = this.CompetitionRepository.Get(competition.Id);
            model.Name = competition.Name;
            model.Description = competition.Description;
            model.Address = competition.Address;
            model.ZipCode = competition.ZipCode;
            model.Latitude = competition.Latitude;
            model.Longitude = competition.Longitude;
            model.StartDate = competition.StartDate;
            model.EndDate = competition.EndDate;
            model.RegistrationStartDate = competition.RegistrationStartDate;
            model.RegistrationEndDate = competition.RegistrationEndDate;
            model.CategoryId = competition.CategoryId;
            model.SpecialtyId = competition.SpecialtyId;
            CompetitionRepository.Save(model);
            return model;
        }

        [Transaction]
        public Competition Delete(Competition competition)
        {
            CompetitionRepository.Delete(this.CompetitionRepository.Get(competition.Id));
            return competition;
        }

        [Transaction]
        public IList<Score> SimulateScore(Competition competition)
        {
            this.ScoreRepository.ResetSimulationScore(competition);
            var horses = this.EnrollmentRepository.GetAllQueryable()
                .Where(x => x.Id.CompetitionId == competition.Id)
                .Select(x => x.Horse).ToList();

            var judges = this.SeminaryRepository.GetAllQueryable()
                .Where(x => x.Id.CompetitionId == competition.Id)
                .Select(x => x.Judge).ToList();
            var scores = new List<Score>(judges.Count * horses.Count);

            judges.ForEach(x =>
            {
                horses.ForEach(y =>
                {
                    this.WeightAthleteSaddleExceededPolicy.CheckSatisfiedBy(y.Athlete, competition.Specialty);
                    scores.Add(new Score()
                    {
                        Id = new ScoreId()
                        {
                            CompetitionId = competition.Id,
                            HorseId = y.Id,
                            JudgeId = x.Id
                        },
                        Value = new Random().Next(0, 10)
                    });
                    this.ScoreRepository.Save(scores);
                });
            });
            return scores;
        }

        [Transaction(ReadOnly = true)]
        public IList<Ranking> AdultRankingsBySpecialty(Specialty specialty)
        {
            return this.ScoreRepository.GetAllQueryable()
                .Where(x => x.Competition.Name.StartsWith("Adulto") && x.Competition.Specialty.Id == specialty.Id)
                .OrderByDescending(x => x.Value)
                .GroupBy(x => x.Horse.Athlete)
                .Select(x => new Ranking
                {
                    Athlete = x.Key,
                    Value = x.Sum(y => y.Value)
                }).Take(3).ToList();
        }
    }
}