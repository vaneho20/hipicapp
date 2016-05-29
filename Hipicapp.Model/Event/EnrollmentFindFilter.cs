namespace Hipicapp.Model.Event
{
    public class EnrollmentFindFilter
    {
        public string Name { get; set; }

        public string ZipCode { get; set; }

        public long? AthleteId { get; set; }

        public long? HorseId { get; set; }

        public long? CompetitionId { get; set; }
    }
}