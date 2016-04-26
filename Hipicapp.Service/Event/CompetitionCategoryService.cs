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
            return this.CompetitionCategoryRepository.GetAll();
        }

        [Transaction(ReadOnly = true)]
        public Page<CompetitionCategory> Paginated(CompetitionCategoryFindFilter filter, PageRequest pageRequest)
        {
            return this.CompetitionCategoryRepository.Paginated(CompetitionCategoryPredicates.ValueOf(filter, this.CompetitionCategoryRepository.GetAllQueryable()), pageRequest);
        }

        [Transaction(ReadOnly = true)]
        public CompetitionCategory Get(long? id)
        {
            return this.CompetitionCategoryRepository.Get(id);
        }

        [Transaction]
        public CompetitionCategory Save(CompetitionCategory competitionCategory)
        {
            CompetitionCategoryRepository.Save(competitionCategory);
            return competitionCategory;
        }

        [Transaction]
        public CompetitionCategory Update(CompetitionCategory competitionCategory)
        {
            var model = this.CompetitionCategoryRepository.Get(competitionCategory.Id);
            model.Name = competitionCategory.Name;
            CompetitionCategoryRepository.Save(model);
            return model;
        }

        [Transaction]
        public CompetitionCategory Delete(CompetitionCategory competitionCategory)
        {
            CompetitionCategoryRepository.Delete(this.CompetitionCategoryRepository.Get(competitionCategory.Id));
            return competitionCategory;
        }
    }
}