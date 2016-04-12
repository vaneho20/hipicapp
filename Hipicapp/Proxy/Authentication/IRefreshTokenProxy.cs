using Hipicapp.Model.Authentication;
using Hipicapp.Utils.Pager;
using System.Collections.Generic;

namespace Hipicapp.Proxy.Authentication
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