using FluentNHibernate.Mapping;
using Hipicapp.Model.Abstract;
using Hipicapp.Model.Account;
using Hipicapp.Model.File;
using Hipicapp.Utils.Util;
using Hipicapp.Utils.Validator;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;
using NSoup.Safety;

namespace Hipicapp.Model.Participant
{
    [JsonObject]
    public class Judge : Entity<long?>
    {
        public virtual long? PhotoId { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(Whitelist.None)]
        public virtual string Name { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(Whitelist.None)]
        public virtual string Surnames { get; set; }

        [NotNull]
        public virtual Gender? Gender { get; set; }

        public virtual FileInfo Photo { get; set; }

        public virtual bool? Assign { get; set; }
    }

    public class JudgeMap : EntityMap<Judge, long?>
    {
        public JudgeMap()
        {
            Table("JUDGE");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").GeneratedBy.Native();

            Map(x => x.PhotoId).Column("PHOTO_ID").Nullable();
            Map(x => x.Name).Column("NAME").Not.Nullable();
            Map(x => x.Surnames).Column("SURNAMES");
            Map(x => x.Gender).Column("GENDER").CustomType<GenericEnumMapper<Gender>>().Not.Nullable();

            References<FileInfo>(x => x.Photo).Column("PHOTO_ID").NotFound.Ignore().LazyLoad().Fetch.Join().ReadOnly();
        }
    }
}