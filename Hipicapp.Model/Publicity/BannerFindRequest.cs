using Hipicapp.Model.Abstract;

namespace Hipicapp.Model.Publicity
{
    public class BannerFindRequest : AbstractFindRequest
    {
        public BannerFindFilter Filter { get; set; }
    }
}