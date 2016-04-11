using Hipica.Model.File;
using Hipica.Repository.Abstract;

namespace Hipica.Repositories.File
{
    public interface IFileContentRepository : IEntityRepository<FileContent, long?>
    {
    }
}