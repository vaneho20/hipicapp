using Hipicapp.Model.Publicity;
using Hipicapp.Repository.Abstract;
using Spring.Stereotype;

namespace Hipicapp.Repository.Publicity
{
    [Repository]
    public class BannerRepository : EntityRepository<Banner, long?>, IBannerRepository
    {
    }
}