using Hipicapp.Model.Event;
using Hipicapp.Repository.Event;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;

namespace Hipicapp.Service.Event
{
    [Service]
    public class CompetitionCategoryService : ICompetitionCategoryService
    {
        [Autowired]
        private ICompetitionCategoryRepository CompetitionCategoryRepository { get; set; }

        [Transaction(ReadOnly = true)]
        public IList<CompetitionCategory> FindAll()
        {
            return CompetitionCategoryRepository.GetAll();
        }

        [Transaction(ReadOnly = true)]
        public Page<CompetitionCategory> Paginated(CompetitionCategoryFindFilter filter, PageRequest pageRequest)
        {
            return CompetitionCategoryRepository.Paginated(CompetitionCategoryRepository.GetAllQueryable(), pageRequest);
        }

        [Transaction(ReadOnly = true)]
        public CompetitionCategory Get(long? id)
        {
            return this.CompetitionCategoryRepository.Get(id);
        }

        [Transaction]
        public CompetitionCategory Save(CompetitionCategory competition)
        {
            CompetitionCategoryRepository.Save(competition);
            return competition;
        }

        [Transaction]
        public CompetitionCategory Update(CompetitionCategory competition)
        {
            var model = this.CompetitionCategoryRepository.Get(competition.Id);
            model.Name = competition.Name;
            CompetitionCategoryRepository.Save(model);
            return model;
        }

        [Transaction]
        public CompetitionCategory Delete(CompetitionCategory competition)
        {
            CompetitionCategoryRepository.Delete(this.CompetitionCategoryRepository.Get(competition.Id));
            return competition;
        }
    }
}