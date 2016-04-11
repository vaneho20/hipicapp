using Hipica.Model.File;
using Hipica.Repository.Abstract;
using Spring.Stereotype;

namespace Hipica.Repositories.File
{
    [Repository]
    public class FileContentRepository : EntityRepository<FileContent, long?>, IFileContentRepository
    {
    }
}