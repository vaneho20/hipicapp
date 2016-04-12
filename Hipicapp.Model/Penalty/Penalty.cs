using Hipicapp.Model.Abstract;
using Newtonsoft.Json;

namespace Hipicapp.Model.Penalty
{
    [JsonObject]
    public class Penalty : Entity<long?>
    {
        public virtual string Name { get; set; }
    }

    public class PenaltyMap : EntityMap<Penalty, long?>
    {
        public PenaltyMap()
        {
            Table("PENALTY");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID");

            Map(x => x.Name).Column("NAME");
        }
    }
}