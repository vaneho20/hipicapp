using Hipicapp.Model.Abstract;

namespace Hipicapp.Model.Participant
{
    public class JudgeFindRequest : AbstractFindRequest
    {
        public JudgeFindFilter Filter { get; set; }
    }
}