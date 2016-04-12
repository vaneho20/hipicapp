using Editorial.Service.Dao.Abstract;
using Editorial.Service.Model.Account;

namespace Editorial.Service.Dao.Account
{
    public interface IAccountDao : IDao<UserProfile, long>, ISupportsSave<UserProfile, long>, ISupportsDelete<UserProfile>
    {
        UserProfile Get(string username);
    }
}