using Hipicapp.Model.Abstract;
using Hipicapp.Model.Event;
using Hipicapp.Model.File;
using Hipicapp.Utils.Util;
using Hipicapp.Utils.Validator;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;
using System;

namespace Hipicapp.Model.Publicity
{
    [JsonObject]
    public class Banner : Entity<long?>
    {
        [NotNull]
        [Min(0)]
        public virtual long? SpecialtyId { get; set; }

        public virtual long? ImageId { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(WhiteListType.NONE)]
        public virtual string Title { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Min = 1, Max = ValidationUtils.MAX_LENGTH_URL)]
        [SafeHtml(WhiteListType.NONE)]
        public virtual string Web { get; set; }

        [NotNull]
        public virtual bool? Visible { get; set; }

        public virtual DateTime? CreationDate { get; set; }

        public virtual FileInfo Image { get; set; }

        public virtual Specialty Specialty { get; set; }
    }

    public class BannerMap : EntityMap<Banner, long?>
    {
        public BannerMap()
        {
            Table("BANNER");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").GeneratedBy.Native();

            Map(x => x.ImageId).Column("IMAGE_ID").Nullable();
            Map(x => x.SpecialtyId).Column("SPECIALTY_ID").Not.Nullable();
            Map(x => x.Title).Column("TITLE").Not.Nullable().Length(ValidationUtils.MAX_LENGTH_DESCRIPTION);
            Map(x => x.Web).Column("WEB").Not.Nullable().Length(ValidationUtils.MAX_LENGTH_URL);
            Map(x => x.CreationDate).Column("CREATION_DATE").Not.Nullable();
            Map(x => x.Visible).Column("VISIBLE").Not.Nullable();

            References<FileInfo>(x => x.Image).Column("IMAGE_ID").NotFound.Ignore().LazyLoad().Fetch.Join().ReadOnly();
            References<Specialty>(x => x.Specialty).Column("SPECIALTY_ID").Fetch.Join().Not.LazyLoad().ReadOnly();
        }
    }
}