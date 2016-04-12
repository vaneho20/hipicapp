using Hipicapp.Utils.Pager;

namespace Hipicapp.Model.Abstract
{
    public abstract class AbstractFindRequest
    {
        public PageRequest PageRequest { get; set; }
    }
}