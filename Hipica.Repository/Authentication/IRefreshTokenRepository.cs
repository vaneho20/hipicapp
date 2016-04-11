using Hipica.Model.Authentication;
using Hipica.Repository.Abstract;

namespace Hipica.Repository.Authentication
{
    public interface IRefreshTokenRepository : IEntityRepository<RefreshToken, string>
    {
    }
}