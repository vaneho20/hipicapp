using Hipicapp.Model.Abstract;
using Hipicapp.Utils.Validator;
using Newtonsoft.Json;
using NSoup.Safety;

namespace Hipicapp.Model.Penalty
{
    [JsonObject]
    public class Penalty : Entity<long?>
    {
        [SafeHtml(Whitelist.None)]
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