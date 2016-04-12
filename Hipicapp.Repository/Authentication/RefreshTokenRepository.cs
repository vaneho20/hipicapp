using Hipicapp.Model.Authentication;
using Hipicapp.Repository.Abstract;
using Spring.Stereotype;

namespace Hipicapp.Repository.Authentication
{
    [Repository]
    public class RefreshTokenRepository : EntityRepository<RefreshToken, string>, IRefreshTokenRepository
    {
    }
}