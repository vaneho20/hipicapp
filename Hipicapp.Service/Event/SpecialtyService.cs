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
    public class SpecialtyService : ISpecialtyService
    {
        [Autowired]
        private ISpecialtyRepository SpecialtyRepository { get; set; }

        [Transaction(ReadOnly = true)]
        public IList<Specialty> FindAll()
        {
            return this.SpecialtyRepository.GetAll();
        }

        [Transaction(ReadOnly = true)]
        public Page<Specialty> Paginated(SpecialtyFindFilter filter, PageRequest pageRequest)
        {
            return this.SpecialtyRepository.Paginated(SpecialtyPredicates.ValueOf(filter, this.SpecialtyRepository.GetAllQueryable()), pageRequest);
        }

        [Transaction(ReadOnly = true)]
        public Specialty Get(long? id)
        {
            return this.SpecialtyRepository.Get(id);
        }

        [Transaction]
        public Specialty Save(Specialty specialty)
        {
            SpecialtyRepository.Save(specialty);
            return specialty;
        }

        [Transaction]
        public Specialty Update(Specialty specialty)
        {
            var model = this.SpecialtyRepository.Get(specialty.Id);
            model.Name = specialty.Name;
            SpecialtyRepository.Save(model);
            return model;
        }

        [Transaction]
        public Specialty Delete(Specialty specialty)
        {
            SpecialtyRepository.Delete(this.SpecialtyRepository.Get(specialty.Id));
            return specialty;
        }
    }
}