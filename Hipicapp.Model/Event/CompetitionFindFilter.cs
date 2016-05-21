namespace Hipicapp.Model.Event
{
    public class CompetitionFindFilter
    {
        public string Name { get; set; }

        public string ZipCode { get; set; }

        public long? AthleteId { get; set; }

        public long? SpecialtyId { get; set; }

        public long? JudgeId { get; set; }
    }
}