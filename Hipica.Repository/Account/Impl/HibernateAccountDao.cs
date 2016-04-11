using Editorial.Service.Dao.Abstract;
using Editorial.Service.Model.Account;
using Editorial.Service.Pager;
using NHibernate;
using Spring.Stereotype;
using System.Collections.Generic;

namespace Editorial.Service.Dao.Account.Impl
{
    [Repository]
    public class HibernateAccountDao : HibernateDao, IAccountDao
    {
        public Model.Account.UserProfile Get(long id)
        {
            return this.CurrentSession.Get<UserProfile>(id);
        }

        public UserProfile Get(string username)
        {
            IQuery query = CurrentSession.CreateQuery("from UserProfile where UserName = :username");
            query.SetString("username", username);

            return query.UniqueResult<UserProfile>();
        }

        public Page<Model.Account.UserProfile> GetAll()
        {
            return GetAll<UserProfile>();
        }

        public Page<Model.Account.UserProfile> Paginated(PageRequest pageRequest)
        {
            return Paginated<UserProfile>(CurrentSession.CreateCriteria<UserProfile>(), pageRequest);
        }

        public long Save(Model.Account.UserProfile entity)
        {
            CurrentSession.SaveOrUpdate(entity);
            return 0;
        }

        public void Update(Model.Account.UserProfile entity)
        {
            CurrentSession.SaveOrUpdate(entity);
        }

        public void Delete(Model.Account.UserProfile entity)
        {
            CurrentSession.Delete(entity);
        }

        public void Save(IList<UserProfile> entity)
        {
            foreach (UserProfile u in entity)
            {
                this.Save(u);
            }
        }
    }
}