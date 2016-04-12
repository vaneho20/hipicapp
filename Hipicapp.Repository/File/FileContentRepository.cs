using Hipicapp.Model.File;
using Hipicapp.Repository.Abstract;
using Spring.Stereotype;

namespace Hipicapp.Repositories.File
{
    [Repository]
    public class FileContentRepository : EntityRepository<FileContent, long?>, IFileContentRepository
    {
    }
}