using Hipicapp.Model.Abstract;
using Hipicapp.Utils.Util;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;
using System;

namespace Hipicapp.Model.Event
{
    [JsonObject]
    public class Competition : Entity<long?>
    {
        [NotNull]
        [Min(0)]
        public virtual long? CategoryId { get; set; }

        [NotNull]
        [Min(0)]
        public virtual long? SpecialtyId { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        public virtual string Name { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DESCRIPTION)]
        public virtual string Description { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        public virtual string Address { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Min = ValidationUtils.LENGTH_ZIPCODE, Max = ValidationUtils.LENGTH_ZIPCODE)]
        public virtual string ZipCode { get; set; }

        [NotNull]
        [Min(ValidationUtils.MIN_LATITUDE)]
        [Max(ValidationUtils.MAX_LATITUDE)]
        public virtual double? Latitude { get; set; }

        [NotNull]
        [Min(ValidationUtils.MIN_LONGITUDE)]
        [Max(ValidationUtils.MAX_LONGITUDE)]
        public virtual double? Longitude { get; set; }

        [NotNull]
        [Future]
        public virtual DateTime? Date { get; set; }

        [NotNull]
        [Future]
        public virtual DateTime? RegistrationDeadline { get; set; }

        public virtual CompetitionCategory Category { get; set; }

        public virtual Specialty Specialty { get; set; }
    }

    public class CompetitionMap : EntityMap<Competition, long?>
    {
        public CompetitionMap()
        {
            Table("COMPETITION");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").GeneratedBy.Native();

            Map(x => x.CategoryId).Column("CATEGORY_ID").Not.Nullable();
            Map(x => x.SpecialtyId).Column("SPECIALTY_ID").Not.Nullable();
            Map(x => x.Name).Column("NAME").Not.Nullable();
            Map(x => x.Description).Column("DESCRIPTION").Not.Nullable().Length(ValidationUtils.MAX_LENGTH_DESCRIPTION);
            Map(x => x.Address).Column("ADDRESS").Not.Nullable();
            Map(x => x.ZipCode).Column("ZIP_CODE").Not.Nullable().Length(ValidationUtils.LENGTH_ZIPCODE);
            Map(x => x.Latitude).Column("LATITUDE").Not.Nullable();
            Map(x => x.Longitude).Column("LONGITUDE").Not.Nullable();
            Map(x => x.Date).Column("_DATE").Not.Nullable();

            References<CompetitionCategory>(x => x.Category).Column("CATEGORY_ID").Fetch.Join().Not.LazyLoad().ReadOnly();
            References<Specialty>(x => x.Specialty).Column("SPECIALTY_ID").Fetch.Join().Not.LazyLoad().ReadOnly();
        }
    }
}