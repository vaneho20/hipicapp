using Hipica.Model.Abstract;
using Hipica.Utils.Util;
using Newtonsoft.Json;
using NHibernate.Type;
using NHibernate.Validator.Constraints;

namespace Hipica.Model.File
{
    [JsonObject]
    public class FileContent : Entity<long?>
    {
        [NotNull]
        [Size(Max = ValidationUtils.MAX_FILE_SIZE)]
        public virtual byte[] Contents { get; set; }

        public virtual FileInfo FileInfo { get; set; }

        public class Properties
        {
            private Properties()
            {
            }

            public const string FILE_ID = "Id";
            public const string FILE_INFO = "FileInfo";
            public const string CONTENTS = "Contents";
        }
    }

    public class FileContentClassMap : EntityMap<FileContent, long?>
    {
        public FileContentClassMap()
        {
            Table("FILE_CONTENT");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").GeneratedBy.Foreign(FileContent.Properties.FILE_INFO);

            Map(x => x.Contents).Column("CONTENTS").CustomType<BinaryBlobType>().Not.Nullable();

            HasOne<FileInfo>(x => x.FileInfo).Constrained().LazyLoad().Cascade.All().Fetch.Join();
        }
    }
}