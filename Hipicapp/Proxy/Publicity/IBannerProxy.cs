using Hipicapp.Model.File;
using Hipicapp.Model.Publicity;
using Hipicapp.Utils.Pager;

namespace Hipicapp.Proxy.Publicity
{
    public interface IBannerProxy
    {
        Page<Banner> Paginated(BannerFindRequest request);

        Banner Get(long? id);

        Banner Save(Banner banner);

        Banner Update(Banner banner);

        Banner Delete(Banner banner);

        FileInfo Upload(long? id, FileInfo file);
    }
}