using Hipica.Model.File;
using Hipica.Repository.Abstract;
using NHibernate.Criterion;
using Spring.Stereotype;

namespace Hipica.Repositories.File
{
    [Repository]
    public class FileInfoRepository : EntityRepository<FileInfo, long?>, IFileInfoRepository
    {
        public FileInfo GetFileUuid(string fileUuid)
        {
            return CurrentSession.CreateCriteria<FileInfo>().Add(Restrictions.Eq(FileInfo.Properties.FILE_UUID, fileUuid)).UniqueResult<FileInfo>();
        }
    }
}