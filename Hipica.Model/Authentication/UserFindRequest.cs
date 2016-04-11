using Hipica.Model.Abstract;

namespace Hipica.Model.Authentication
{
    public class UserFindRequest : AbstractFindRequest
    {
        public UserFindFilter Filter { get; set; }
    }
}