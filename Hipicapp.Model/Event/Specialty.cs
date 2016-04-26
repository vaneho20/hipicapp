using Hipicapp.Model.Abstract;
using Hipicapp.Utils.Util;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;

namespace Hipicapp.Model.Event
{
    [JsonObject]
    public class Specialty : Entity<long?>
    {
        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        public virtual string Name { get; set; }

        public virtual int? MinAgeOfHorse { get; set; }

        public virtual int? MaxNoOfJudges { get; set; }

        public virtual float? MaxWeightOfAthlWithSaddle { get; set; }
    }

    public class SpecialtyMap : EntityMap<Specialty, long?>
    {
        public SpecialtyMap()
        {
            Table("SPECIALTY");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").GeneratedBy.Native();

            Map(x => x.Name).Column("NAME").Not.Nullable();
            Map(x => x.MinAgeOfHorse).Column("MIN_AGE_OF_HORSE");
            Map(x => x.MaxNoOfJudges).Column("MAX_NO_OF_JUDGES");
            Map(x => x.MaxWeightOfAthlWithSaddle).Column("MAX_W_OF_ATHL_WITH_SADDLE");
        }
    }
}