using Hipicapp.Model.Abstract;
using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Util;
using Hipicapp.Utils.Validator;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;
using System;
using System.Collections.Generic;

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

        public virtual long? PhotoId { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(WhiteListType.NONE)]
        public virtual string Name { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DESCRIPTION)]
        [SafeHtml(WhiteListType.NONE)]
        public virtual string Description { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(WhiteListType.NONE)]
        public virtual string Address { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Min = ValidationUtils.LENGTH_ZIPCODE, Max = ValidationUtils.LENGTH_ZIPCODE)]
        [SafeHtml(WhiteListType.NONE)]
        public virtual string ZipCode { get; set; }

        /*[NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]*/

        [SafeHtml(WhiteListType.NONE)]
        public virtual string PlaceId { get; set; }

        [NotNull]
        //[Future]
        public virtual DateTime? StartDate { get; set; }

        [NotNull]
        [Future]
        public virtual DateTime? EndDate { get; set; }

        [NotNull]
        //[Future]
        public virtual DateTime? RegistrationStartDate { get; set; }

        [NotNull]
        //[Future]
        public virtual DateTime? RegistrationEndDate { get; set; }

        public virtual DateTime? CreationDate { get; set; }

        public virtual bool? Finalized { get; set; }

        public virtual CompetitionCategory Category { get; set; }

        public virtual Specialty Specialty { get; set; }

        public virtual FileInfo Photo { get; set; }

        [JsonIgnore]
        public virtual ISet<Enrollment> Inscriptions { get; set; }

        [JsonIgnore]
        public virtual ISet<Seminary> Seminary { get; set; }
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
            Map(x => x.PhotoId).Column("PHOTO_ID").Nullable();
            Map(x => x.Name).Column("NAME").Not.Nullable();
            Map(x => x.Description).Column("DESCRIPTION").Not.Nullable().Length(ValidationUtils.MAX_LENGTH_DESCRIPTION);
            Map(x => x.Address).Column("ADDRESS").Not.Nullable();
            Map(x => x.ZipCode).Column("ZIP_CODE").Not.Nullable().Length(ValidationUtils.LENGTH_ZIPCODE);
            Map(x => x.PlaceId).Column("PLACE_ID").Not.Nullable();
            Map(x => x.StartDate).Column("START_DATE").Not.Nullable();
            Map(x => x.EndDate).Column("END_DATE").Not.Nullable();
            Map(x => x.RegistrationStartDate).Column("REG_START_DATE").Not.Nullable();
            Map(x => x.RegistrationEndDate).Column("REG_END_DATE").Not.Nullable();
            Map(x => x.CreationDate).Column("CREATION_DATE").Not.Nullable();
            Map(x => x.Finalized).Column("FINALIZED").Nullable();

            References<CompetitionCategory>(x => x.Category).Column("CATEGORY_ID").Fetch.Join().Not.LazyLoad().ReadOnly();
            References<FileInfo>(x => x.Photo).Column("PHOTO_ID").NotFound.Ignore().LazyLoad().Fetch.Join().ReadOnly();
            References<Specialty>(x => x.Specialty).Column("SPECIALTY_ID").Fetch.Join().Not.LazyLoad().ReadOnly();

            HasMany<Enrollment>(x => x.Inscriptions).KeyColumn("COMPETITION_ID").NotFound.Ignore().LazyLoad();
            HasMany<Seminary>(x => x.Seminary).KeyColumn("COMPETITION_ID").NotFound.Ignore().LazyLoad();
        }
    }
}