using Hipicapp.Model.Authentication;
using Hipicapp.Repository.Authentication;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;

namespace Hipicapp.Service.Authentication
{
    [Service]
    [Transaction(ReadOnly = true)]
    public class RefreshTokenService : IRefreshTokenService
    {
        [Autowired]
        private IRefreshTokenRepository refreshTokenRepository { get; set; }

        [Transaction(ReadOnly = false)]
        public string Save(Model.Authentication.RefreshToken entity)
        {
            return refreshTokenRepository.Save(entity);
        }

        [Transaction(ReadOnly = false)]
        public void Save(IList<Model.Authentication.RefreshToken> entity)
        {
            refreshTokenRepository.Save(entity);
        }

        [Transaction(ReadOnly = false)]
        public void Update(Model.Authentication.RefreshToken entity)
        {
            refreshTokenRepository.Update(entity);
        }

        public Model.Authentication.RefreshToken Get(string id)
        {
            return refreshTokenRepository.Get(id);
        }

        public IList<Model.Authentication.RefreshToken> GetAll()
        {
            return refreshTokenRepository.GetAll();
        }

        public Utils.Pager.Page<Model.Authentication.RefreshToken> Paginated(Utils.Pager.PageRequest pageRequest)
        {
            return refreshTokenRepository.Paginated(pageRequest);
        }

        [Transaction(ReadOnly = false)]
        public void Delete(RefreshToken entity)
        {
            refreshTokenRepository.Delete(entity);
        }
    }
}