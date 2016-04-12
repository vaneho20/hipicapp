using Hipicapp.Model.Abstract;

namespace Hipicapp.Model.Authentication
{
    public class UserFindRequest : AbstractFindRequest
    {
        public UserFindFilter Filter { get; set; }
    }
}