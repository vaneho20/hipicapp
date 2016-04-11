using Hipica.Model.Abstract;

namespace Hipica.Model.Athlete
{
    public class AthleteFindRequest : AbstractFindRequest
    {
        public AthleteFindFilter Filter { get; set; }
    }
}