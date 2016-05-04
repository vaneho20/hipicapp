using Hipicapp.Model.Abstract;
using Hipicapp.Utils.Util;
using Hipicapp.Utils.Validator;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;
using NSoup.Safety;

namespace Hipicapp.Model.File
{
    [JsonObject]
    public class FileInfo : Entity<long?>
    {
        [NotNull]
        [NotEmpty]
        [Size(Min = 36, Max = 36)]
        [SafeHtml(Whitelist.None)]
        public virtual string FileUuid { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(Whitelist.None)]
        public virtual string FileName { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(Whitelist.None)]
        public virtual string ContentType { get; set; }

        [JsonIgnore]
        public virtual byte[] Contents { get; set; }

        public class Properties
        {
            private Properties()
            {
            }

            public const string FILE_ID = "Id";
            public const string FILE_UUID = "FileUuid";
            public const string FILE_NAME = "FileName";
            public const string CONTENT_TYPE = "ContentType";
            public const string CONTENT_LENGTH = "ContentLength";
            public const string CONTENTS = "Contents";
        }
    }

    public class FileInfoClassMap : EntityMap<FileInfo, long?>
    {
        public FileInfoClassMap()
        {
            Table("FILE_INFO");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").GeneratedBy.Native();

            Map(x => x.FileUuid).Column("FILE_UUID").Length(36).Unique();
            Map(x => x.FileName).Column("FILE_NAME");
            Map(x => x.ContentType).Column("CONTENT_TYPE");
        }
    }
}