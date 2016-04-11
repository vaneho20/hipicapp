using Hipica.Model.Authentication;
using Hipica.Utils.Pager;
using System.Collections.Generic;

namespace Hipica.Proxy.Authentication
{
    public interface IRefreshTokenProxy
    {
        RefreshToken Get(string id);

        IList<RefreshToken> GetAll();

        Page<RefreshToken> Paginated(PageRequest pageRequest);

        string Save(RefreshToken entity);

        void Save(IList<RefreshToken> entity);

        void Update(RefreshToken entity);

        void Delete(RefreshToken entity);
    }
}