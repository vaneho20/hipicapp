using Hipicapp.Model.Abstract;
using NHibernate;

namespace Hipicapp.Repository.Abstract
{
    public interface IEntityRepository<T, K> : IRepository<T, K> where T : Entity<K>
    {
        FlushMode FlushMode { get; set; }
    }
}