using Hipicapp.Model.Account;
using Hipicapp.Repository.Abstract;

namespace Hipicapp.Repository.Account
{
    public interface IUserRepository : IEntityRepository<User, long?>
    {
        User GetByUserName(string email);
    }
}