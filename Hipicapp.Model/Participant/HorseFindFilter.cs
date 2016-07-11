using Hipicapp.Model.Account;

namespace Hipicapp.Model.Participant
{
    public class HorseFindFilter
    {
        public string Name { get; set; }

        public long? AthleteId { get; set; }

        public Gender? Gender { get; set; }

        public long? SpecialtyId { get; set; }

        public long? CompetitionId { get; set; }
    }
}