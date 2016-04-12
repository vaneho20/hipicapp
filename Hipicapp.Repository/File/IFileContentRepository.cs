using Hipicapp.Model.File;
using Hipicapp.Repository.Abstract;

namespace Hipicapp.Repositories.File
{
    public interface IFileContentRepository : IEntityRepository<FileContent, long?>
    {
    }
}