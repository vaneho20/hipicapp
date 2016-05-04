using Hipicapp.Model.Abstract;
using Hipicapp.Utils.Util;
using Hipicapp.Utils.Validator;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;
using NSoup.Safety;

namespace Hipicapp.Model.Event
{
    [JsonObject]
    public class CompetitionCategory : Entity<long?>
    {
        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(Whitelist.None)]
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

            Map(x => x.Name).Column("NAME").Not.Nullable();
            Map(x => x.Previous).Column("PREVIOUS");
            Map(x => x.InitialYear).Column("INITIAL_YEAR");
            Map(x => x.Later).Column("LATER");
            Map(x => x.FinalYear).Column("FINAL_YEAR");
        }
    }
}