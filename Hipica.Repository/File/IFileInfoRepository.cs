using Hipica.Model.File;
using Hipica.Repository.Abstract;

namespace Hipica.Repositories.File
{
    public interface IFileInfoRepository : IEntityRepository<FileInfo, long?>
    {
        FileInfo GetFileUuid(string fileUuid);
    }
}