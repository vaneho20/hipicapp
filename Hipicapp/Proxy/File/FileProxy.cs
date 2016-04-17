using Hipicapp.Model.File;
using Hipicapp.Proxy;
using Hipicapp.Services.File;
using Spring.Objects.Factory.Attributes;

namespace Hipicapp.Proxies.File
{
    [Proxy]
    public class FileProxy : IFileProxy
    {
        [Autowired]
        public IFileService FileService { get; set; }

        public FileInfo GetContentsByUuid(string fileUuid)
        {
            return this.FileService.GetContentsByUuid(fileUuid);
        }

        public FileInfo Get(long? fileId)
        {
            return this.FileService.Get(fileId);
        }

        public FileInfo Save(/*Path path*/)
        {
            return null;
            /*try {
                return this.save(path.getFileName().toString(), Files.probeContentType(path), Files.readAllBytes(path));
            } catch (final IOException e) {
                throw new ApplicationRuntimeException(e);
            }*/
        }

        public FileInfo Save(string name, string mimeType, byte[] contents)
        {
            return this.FileService.Save(name, mimeType, contents);
        }

        public FileInfo Update(long? id, string name, string mimeType, byte[] contents)
        {
            return this.FileService.Update(id, name, mimeType, contents);
        }

        public void Delete(FileInfo model)
        {
            this.FileService.Delete(model);
        }
    }
}