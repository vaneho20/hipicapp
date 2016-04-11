using Hipica.Model.Authentication;
using Hipica.Service.Authentication;
using Hipica.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using System.Collections.Generic;

namespace Hipica.Proxy.Authentication
{
    [Proxy]
    public class RefreshTokenProxy : IRefreshTokenProxy
    {
        [Autowired]
        private IRefreshTokenService RefreshTokenService { get; set; }

        public string Save(RefreshToken entity)
        {
            return RefreshTokenService.Save(entity);
        }

        public void Save(IList<RefreshToken> entity)
        {
            RefreshTokenService.Save(entity);
        }

        public void Update(RefreshToken entity)
        {
            RefreshTokenService.Update(entity);
        }

        public RefreshToken Get(string id)
        {
            return RefreshTokenService.Get(id);
        }

        public IList<RefreshToken> GetAll()
        {
            return RefreshTokenService.GetAll();
        }

        public Page<RefreshToken> Paginated(PageRequest pageRequest)
        {
            return RefreshTokenService.Paginated(pageRequest);
        }

        public void Delete(RefreshToken entity)
        {
            RefreshTokenService.Delete(entity);
        }
    }
}