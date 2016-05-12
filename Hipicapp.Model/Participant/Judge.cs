using FluentNHibernate.Mapping;
using Hipicapp.Model.Abstract;
using Hipicapp.Model.Account;
using Hipicapp.Model.Event;
using Hipicapp.Model.File;
using Hipicapp.Utils.Util;
using Hipicapp.Utils.Validator;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;

namespace Hipicapp.Model.Participant
{
    [JsonObject]
    public class Judge : Entity<long?>
    {
        public virtual long? PhotoId { get; set; }

        [NotNull]
        [Min(0)]
        public virtual long? SpecialtyId { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(WhiteListType.NONE)]
        public virtual string Name { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(WhiteListType.NONE)]
        public virtual string Surnames { get; set; }

        [NotNull]
        public virtual Gender? Gender { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(WhiteListType.NONE)]
        public virtual string Federation { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Min = ValidationUtils.LENGTH_ZIPCODE, Max = ValidationUtils.LENGTH_ZIPCODE)]
        [SafeHtml(WhiteListType.NONE)]
        public virtual string ZipCode { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(WhiteListType.NONE)]
        public virtual string PlaceId { get; set; }

        public virtual FileInfo Photo { get; set; }

        public virtual Specialty Specialty { get; set; }

        public virtual bool? Assign { get; set; }
    }

    public class JudgeMap : EntityMap<Judge, long?>
    {
        public JudgeMap()
        {
            Table("JUDGE");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").GeneratedBy.Native();

            Map(x => x.SpecialtyId).Column("SPECIALTY_ID").Not.Nullable();
            Map(x => x.PhotoId).Column("PHOTO_ID").Nullable();
            Map(x => x.Name).Column("NAME").Not.Nullable();
            Map(x => x.Surnames).Column("SURNAMES");
            Map(x => x.Gender).Column("GENDER").CustomType<GenericEnumMapper<Gender>>().Not.Nullable();
            Map(x => x.Federation).Column("FEDERATION").Not.Nullable();
            Map(x => x.ZipCode).Column("ZIP_CODE").Not.Nullable().Length(ValidationUtils.LENGTH_ZIPCODE);
            Map(x => x.PlaceId).Column("PLACE_ID").Not.Nullable();

            References<FileInfo>(x => x.Photo).Column("PHOTO_ID").NotFound.Ignore().LazyLoad().Fetch.Join().ReadOnly();
            References<Specialty>(x => x.Specialty).Column("SPECIALTY_ID").Fetch.Join().Not.LazyLoad().ReadOnly();
        }
    }
}