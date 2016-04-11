using Hipica.Model.Abstract;
using Hipica.Model.File;
using Hipica.Utils.Util;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;

namespace Hipica.Model.Participant
{
    [JsonObject]
    public class Judge : Entity<long?>
    {
        public virtual long? PhotoId { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        public virtual string Name { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        public virtual string Surnames { get; set; }

        public virtual FileInfo Photo { get; set; }
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

            References<FileInfo>(x => x.Photo).Column("PHOTO_ID").NotFound.Ignore().LazyLoad().Fetch.Join().ReadOnly();
        }
    }
}