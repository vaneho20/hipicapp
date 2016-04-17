using Hipicapp.Model.Authentication;
using Hipicapp.Repository.Abstract;

namespace Hipicapp.Repository.Authentication
{
    public interface IRefreshTokenRepository : IEntityRepository<RefreshToken, string>
    {
    }
}