using Hipicapp.Filters;
using Hipicapp.Model.Authentication;
using Hipicapp.Model.File;
using Hipicapp.Model.Publicity;
using Hipicapp.Service.Account;
using Hipicapp.Service.Publicity;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using Spring.Transaction.Interceptor;
using System.Web.Http;

namespace Hipicapp.Proxy.Publicity
{
    [Proxy]
    public class BannerProxy : IBannerProxy
    {
        [Autowired]
        private IBannerService BannerService { get; set; }

        [Autowired]
        private IUserService UserService { get; set; }

        [AllowAnonymous]
        public Page<Banner> Paginated(BannerFindRequest request)
        {
            return this.BannerService.Paginated(request.Filter, request.PageRequest);
        }

        [AllowAnonymous]
        public Banner Get(long? id)
        {
            return this.BannerService.Get(id);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Banner Save(Banner banner)
        {
            return this.BannerService.Save(banner);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Banner Update(Banner banner)
        {
            return this.BannerService.Update(banner);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Banner Delete(Banner banner)
        {
            return this.BannerService.Delete(banner);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        [Transaction]
        public FileInfo Upload(long? id, FileInfo file)
        {
            var banner = this.BannerService.Get(id);
            return this.BannerService.Upload(banner, file.FileName, file.ContentType, file.Contents);
        }
    }
}