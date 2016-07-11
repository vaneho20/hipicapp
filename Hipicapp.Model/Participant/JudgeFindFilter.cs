using Hipicapp.Model.Account;

namespace Hipicapp.Model.Participant
{
    public class JudgeFindFilter
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public Gender? Gender { get; set; }

        public long? CompetitionId { get; set; }

        public long? SpecialtyId { get; set; }
    }
}