using Hipica.Model.Abstract;
using Hipica.Utils.Util;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;
using System;

namespace Hipica.Model.Event
{
    [JsonObject]
    public class Competition : Entity<long?>
    {
        [NotNull]
        [Min(0)]
        public virtual long? CategoryId { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        public virtual string Name { get; set; }

        [NotNull]
        [Past]
        public virtual DateTime? Date { get; set; }

        public virtual CompetitionCategory Category { get; set; }
    }

    public class CompetitionMap : EntityMap<Competition, long?>
    {
        public CompetitionMap()
        {
            Table("COMPETITION");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").GeneratedBy.Native();

            Map(x => x.CategoryId).Column("CATEGORY_ID").Not.Nullable();
            Map(x => x.Name).Column("NAME").Not.Nullable();
            Map(x => x.Date).Column("_DATE").Not.Nullable();

            References<CompetitionCategory>(x => x.Category).Column("CATEGORY_ID").Fetch.Join().Not.LazyLoad().ReadOnly();
        }
    }
}