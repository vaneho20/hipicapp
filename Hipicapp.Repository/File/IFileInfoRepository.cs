using Hipicapp.Model.File;
using Hipicapp.Repository.Abstract;

namespace Hipicapp.Repositories.File
{
    public interface IFileInfoRepository : IEntityRepository<FileInfo, long?>
    {
        FileInfo GetFileUuid(string fileUuid);
    }
}