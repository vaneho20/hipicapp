using Hipica.Model.Abstract;
using NHibernate;

namespace Hipica.Repository.Abstract
{
    public interface IEntityRepository<T, K> : IRepository<T, K> where T : Entity<K>
    {
        FlushMode FlushMode { get; set; }
    }
}