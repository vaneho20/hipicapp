using Hipica.Utils.Pager;

namespace Hipica.Model.Abstract
{
    public abstract class AbstractFindRequest
    {
        public PageRequest PageRequest { get; set; }
    }
}