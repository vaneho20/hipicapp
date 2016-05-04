using Newtonsoft.Json;

namespace Hipicapp.Model.Participant
{
    [JsonObject]
    public class Ranking
    {
        public virtual Athlete Athlete { get; set; }

        public virtual float? Value { get; set; }
    }
}