using Hipica.Model.Abstract;
using Newtonsoft.Json;

namespace Hipica.Model.Event
{
    [JsonObject]
    public class CompetitionCategory : Entity<long?>
    {
        public virtual string Name { get; set; }
    }

    public class CompetitionCategoryMap : EntityMap<CompetitionCategory, long?>
    {
        public CompetitionCategoryMap()
        {
            Table("COMPETITION_CATEGORY");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").GeneratedBy.Native();

            Map(x => x.Name).Column("NAME");
        }
    }
}