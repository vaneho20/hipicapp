using Hipica.Model.Account;
using Hipica.Repository.Abstract;

namespace Hipica.Repository.Account
{
    public interface IUserRepository : IEntityRepository<User, long?>
    {
        User GetByUserName(string email);
    }
}