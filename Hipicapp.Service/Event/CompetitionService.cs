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

        [Transaction(ReadOnly = true)]
        public Page<Competition> Paginated(CompetitionFindFilter filter, PageRequest pageRequest)
        {
            return CompetitionRepository.Paginated(CompetitionRepository.GetAllQueryable(), pageRequest);
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
            model.Date = competition.Date;
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
    }
}