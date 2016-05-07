using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Repository.Event;
using Hipicapp.Repository.Participant;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;
using System.Linq;

namespace Hipicapp.Service.Event
{
    [Service]
    public class SeminaryService : ISeminaryService
    {
        [Autowired]
        private ICompetitionRepository CompetitionRepository { get; set; }

        [Autowired]
        private IJudgeRepository JudgeRepository { get; set; }

        [Autowired]
        private ISeminaryRepository SeminaryRepository { get; set; }

        [Autowired]
        private IMaximumNumberOfJudgesExceededPolicy MaximumNumberOfJudgesExceededPolicy { get; set; }

        [Transaction]
        public IList<Seminary> AssignAllJudges(long? competitionId)
        {
            Competition previousCompetition = this.CompetitionRepository.Get(competitionId);

            this.MaximumNumberOfJudgesExceededPolicy.CheckSatisfiedBy(this.JudgeRepository.GetAllQueryable().Count(), previousCompetition.Specialty);
            //this.updateAllowancePolicy.checkSatisfiedBy(previousCompetition);

            var jury = new List<Seminary>();

            var judges = this.JudgeRepository.GetAll();

            judges.ToList().ForEach(x =>
            {
                var seminaryId = new SeminaryId();
                seminaryId.CompetitionId = competitionId;
                seminaryId.JudgeId = x.Id;

                if (!this.SeminaryRepository.GetAllQueryable().Any(y => y.Id == seminaryId))
                {
                    var seminary = new Seminary();

                    seminary.Id = seminaryId;

                    jury.Add(seminary);
                }
            });

            this.SeminaryRepository.Save(jury);
            return jury;
        }

        [Transaction]
        public IList<Seminary> AssignAllJudgesById(long? competitionId, IList<long?> judgesId)
        {
            Competition previousCompetition = this.CompetitionRepository.Get(competitionId);

            //this.MaximumNumberOfJudgesExceededPolicy.CheckSatisfiedBy(this.JudgeRepository.GetAllQueryable().Count(), previousCompetition.Specialty);
            //this.updateAllowancePolicy.checkSatisfiedBy(previousCompetition);

            var jury = new List<Seminary>();

            var judges = this.JudgeRepository.GetAllQueryable().Where(x => judgesId.Contains(x.Id));

            judges.ToList().ForEach(x =>
                {
                    var seminaryId = new SeminaryId();
                    seminaryId.CompetitionId = competitionId;
                    seminaryId.JudgeId = x.Id;

                    if (!this.SeminaryRepository.GetAllQueryable().Any(y => y.Id == seminaryId))
                    {
                        var seminary = new Seminary();

                        seminary.Id = seminaryId;

                        jury.Add(seminary);
                    }
                });

            this.SeminaryRepository.Save(jury);
            return jury;
        }

        [Transaction]
        public IList<Seminary> AssignAllJudgesByFilter(long? competitionId, JudgeFindFilter filter)
        {
            Competition previousCompetition = this.CompetitionRepository.Get(competitionId);

            //this.MaximumNumberOfJudgesExceededPolicy.CheckSatisfiedBy(this.JudgeRepository.GetAllQueryable().Count(), previousCompetition.Specialty);
            //this.updateAllowancePolicy.checkSatisfiedBy(previousCompetition);

            /*IList<Seminary> seminary = new List<Seminary>();

            Iterable<Judge> judges = this.JudgeRepository.findAll(JudgePredicates
                    .valueOf(filter));

            for (Judge pointOfSaleImpl : judges) {
                SeminaryId seminaryId = new SeminaryId();
                seminaryId.setAggregatorId(filter.getAggregatorId());
                seminaryId.setCompetitionId(competitionId);
                seminaryId.setJudgeId(pointOfSaleImpl.getJudgeId().getJudgeId());

                if (!this.SeminaryRepository.exists(seminaryId)) {
                    Seminary promotionJudge = new Seminary();

                    promotionJudge.setSeminaryId(seminaryId);

                    seminary.add((Seminary) promotionJudge);
                }
            }

            IList<Seminary> judgesAssigned = (List<Seminary>) (List<?>) this.SeminaryRepository
                    .save(seminary);

            return judgesAssigned;*/
            return null;
        }

        [Transaction]
        public IList<Seminary> UnassignAllJudges(long? competitionId)
        {
            Competition previousCompetition = this.CompetitionRepository.Get(competitionId);

            //this.MaximumNumberOfJudgesExceededPolicy.CheckSatisfiedBy(this.JudgeRepository.GetAllQueryable().Count(), previousCompetition.Specialty);
            //this.updateAllowancePolicy.checkSatisfiedBy(previousCompetition);

            var jury = this.SeminaryRepository.GetAllQueryable().Where(x => x.Id.CompetitionId == competitionId).ToList();
            jury.ForEach(x =>
            {
                this.SeminaryRepository.Delete(x.Id);
            });
            return jury;
        }

        [Transaction]
        public IList<Seminary> UnassignAllJudgesById(long? competitionId, IList<long?> judgesId)
        {
            Competition previousCompetition = this.CompetitionRepository.Get(competitionId);

            //this.MaximumNumberOfJudgesExceededPolicy.CheckSatisfiedBy(this.JudgeRepository.GetAllQueryable().Count(), previousCompetition.Specialty);
            //this.updateAllowancePolicy.checkSatisfiedBy(previousCompetition);

            var jury = this.SeminaryRepository.GetAllQueryable().Where(x => x.Id.CompetitionId == competitionId && judgesId.Contains(x.Id.JudgeId)).ToList();
            jury.ForEach(x =>
            {
                this.SeminaryRepository.Delete(x.Id);
            });
            return jury;
        }

        [Transaction]
        public IList<Seminary> UnassignAllJudgesByFilter(long? competitionId, JudgeFindFilter filter)
        {
            Competition previousCompetition = this.CompetitionRepository.Get(competitionId);

            //this.MaximumNumberOfJudgesExceededPolicy.CheckSatisfiedBy(this.JudgeRepository.GetAllQueryable().Count(), previousCompetition.Specialty);
            //this.updateAllowancePolicy.checkSatisfiedBy(previousCompetition);

            /*IList<Seminary> seminary = new List<Seminary>();

            Iterable<Judge> judges = this.JudgeRepository.findAll(JudgePredicates
                    .valueOf(filter));

            for (Judge pointOfSaleImpl : judges) {
                SeminaryId seminaryId = new SeminaryId();
                seminaryId.setAggregatorId(filter.getAggregatorId());
                seminaryId.setCompetitionId(competitionId);
                seminaryId.setJudgeId(pointOfSaleImpl.getJudgeId().getJudgeId());

                if (this.SeminaryRepository.exists(seminaryId)) {
                    Seminary promotionJudge = new Seminary();

                    promotionJudge.setSeminaryId(seminaryId);

                    seminary.add(promotionJudge);
                }
            }

            for (int k = 0; k < seminary.Count; k++) {
                this.SeminaryRepository.delete((SeminaryId) seminary.get(k)
                        .getSeminaryId());
            }

            return seminary;*/
            return null;
        }

        [Transaction]
        public Seminary AssignUnassignJudge(long? competitionId, long? judgeId)
        {
            Competition previousCompetition = this.CompetitionRepository.Get(competitionId);

            this.MaximumNumberOfJudgesExceededPolicy.CheckSatisfiedBy(this.SeminaryRepository.GetAllQueryable().Count(x => x.Competition.Id == competitionId), previousCompetition.Specialty);
            //this.updateAllowancePolicy.checkSatisfiedBy(previousCompetition);

            SeminaryId seminaryId = new SeminaryId();
            seminaryId.CompetitionId = competitionId;
            seminaryId.JudgeId = judgeId;

            Seminary seminary = new Seminary();
            seminary.Id = seminaryId;

            if (this.SeminaryRepository.GetAllQueryable().Any(x => x.Id == seminaryId))
            {
                this.SeminaryRepository.Delete(seminaryId);
            }
            else
            {
                this.SeminaryRepository.Save(seminary);
            }

            return seminary;
        }
    }
}