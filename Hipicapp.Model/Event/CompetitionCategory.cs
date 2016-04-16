using Hipicapp.Model.Abstract;
using Newtonsoft.Json;

namespace Hipicapp.Model.Event
{
    [JsonObject]
    public class CompetitionCategory : Entity<long?>
    {
        public virtual string Name { get; set; }

        public virtual int? InitialYear { get; set; }

        public virtual int? FinalYear { get; set; }

        public virtual bool? Later { get; set; }

        public virtual bool? Previous { get; set; }
    }

    public class CompetitionCategoryMap : EntityMap<CompetitionCategory, long?>
    {
        public CompetitionCategoryMap()
        {
            Table("COMPETITION_CATEGORY");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").GeneratedBy.Native();

            Map(x => x.Name).Column("NAME");
            Map(x => x.Previous).Column("PREVIOUS");
            Map(x => x.InitialYear).Column("INITIAL_YEAR");
            Map(x => x.Later).Column("LATER");
            Map(x => x.FinalYear).Column("FINAL_YEAR");
        }
    }
}