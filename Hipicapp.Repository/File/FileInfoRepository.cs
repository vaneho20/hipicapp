using Hipicapp.Model.File;
using Hipicapp.Repository.Abstract;
using NHibernate.Criterion;
using Spring.Stereotype;

namespace Hipicapp.Repositories.File
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