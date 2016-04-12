using Hipicapp.Utils.Pager;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace Hipicapp.Repository.Abstract
{
    public interface IRepository<T, K>
    {
        K Save(T entity);

        void Save(IList<T> entity);

        T Get(K id);

        IList<T> GetAll();

        IQueryable<T> GetAllQueryable();

        Page<T> Paginated(PageRequest pageRequest);

        Page<T> Paginated(ICriteria criteria, PageRequest pageRequest);

        Page<T> Paginated(IQueryable<T> query, PageRequest pageRequest);

        void Update(T entity);

        void Delete(T entity);

        void Delete(K id);

        //Page<T> Paginated(FindRequestImpl<TSearch> filter);
    }
}