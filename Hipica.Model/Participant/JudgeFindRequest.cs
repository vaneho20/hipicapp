using Hipica.Model.Abstract;

namespace Hipica.Model.Participant
{
    public class JudgeFindRequest : AbstractFindRequest
    {
        public JudgeFindFilter Filter { get; set; }
    }
}