using Hipica.Model.Abstract;
using Hipica.Utils.Pager;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Spring.Objects.Factory.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hipica.Repository.Abstract
{
    public abstract class EntityRepository<T, K> : IEntityRepository<T, K> where T : Entity<K>
    {
        private ISessionFactory sessionFactory;

        [Autowired]
        public ISessionFactory SessionFactory
        {
            protected get
            {
                return sessionFactory;
            }
            set
            {
                sessionFactory = value;
            }
        }

        protected ISession CurrentSession
        {
            get
            {
                return sessionFactory.GetCurrentSession();
            }
        }

        public FlushMode FlushMode
        {
            get
            {
                return this.CurrentSession.FlushMode;
            }
            set
            {
                this.CurrentSession.FlushMode = value;
            }
        }

        public K Save(T entity)
        {
            return (K)CurrentSession.Save(entity);
        }

        public void Save(IList<T> entities)
        {
            foreach (T entity in entities)
            {
                CurrentSession.Save(entity);
            }
        }

        public T Get(K id)
        {
            return CurrentSession.Get<T>(id);
        }

        public IQueryable<T> GetAllQueryable()
        {
            return CurrentSession.Query<T>();
        }

        public IList<T> GetAll()
        {
            return CurrentSession.CreateCriteria<T>().List<T>();
        }

        public Page<T> Paginated(PageRequest pageRequest)
        {
            return Paginated(CurrentSession.CreateCriteria<T>(), pageRequest);
        }

        public Page<T> Paginated(ICriteria criteria, PageRequest pageRequest)
        {
            criteria.SetFirstResult(pageRequest.Offset);
            criteria.SetMaxResults(pageRequest.Size);

            if (pageRequest.Sort != null && pageRequest.Sort.Orders != null && pageRequest.Sort.Orders.Count > 0)
            {
                foreach (var o in pageRequest.Sort.Orders)
                {
                    if (o.Ascending)
                    {
                        criteria.AddOrder(NHibernate.Criterion.Order.Asc(o.Property));
                    }
                    else
                    {
                        criteria.AddOrder(NHibernate.Criterion.Order.Desc(o.Property));
                    }
                }
            }

            IList<T> result = criteria.List<T>();

            criteria.SetFirstResult(0);
            criteria.SetMaxResults(1);

            long totalElements = criteria.SetProjection(Projections.Count(Projections.Id())).UniqueResult<int>();

            return new Page<T>(result, result.Count, pageRequest.Page, result.Count, pageRequest.Sort, totalElements, pageRequest.Size);
        }

        public Page<T> Paginated(IQueryable<T> query, PageRequest pageRequest)
        {
            int total = query.Count();
            query.Skip(pageRequest.Offset).Take(pageRequest.Size);

            if (pageRequest.Sort != null && pageRequest.Sort.Orders != null && pageRequest.Sort.Orders.Count > 0)
            {
                foreach (var o in pageRequest.Sort.Orders)
                {
                    var x = System.Linq.Expressions.Expression.Parameter(typeof(T), "x");
                    var expression = System.Linq.Expressions.Expression.Lambda<Func<T, object>>(System.Linq.Expressions.Expression.Property(x, o.Property), x);
                    if (o.Ascending)
                    {
                        query.OrderBy(expression);
                    }
                    else
                    {
                        query.OrderByDescending(expression);
                    }
                }
            }

            IList<T> result = query.ToList<T>();

            return new Page<T>(result, result.Count, pageRequest.Page, result.Count, pageRequest.Sort, total, pageRequest.Size);
        }

        public void Update(T entity)
        {
            CurrentSession.Update(entity);
        }

        public void Delete(T entity)
        {
            CurrentSession.Delete(entity);
        }

        public void Delete(K id)
        {
            CurrentSession.Delete(id);
        }
    }
}