using Hipicapp.Model.File;
using Hipicapp.Model.Publicity;
using Hipicapp.Utils.Pager;

namespace Hipicapp.Service.Publicity
{
    public interface IBannerService
    {
        Page<Banner> Paginated(BannerFindFilter filter, PageRequest pageRequest);

        Banner Get(long? id);

        Banner Save(Banner banner);

        Banner Update(Banner banner);

        Banner Delete(Banner banner);

        FileInfo Upload(Banner banner, string name, string mimeType, byte[] bytes);
    }
}