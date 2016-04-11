using Hipica.Model.File;
using Spring.Stereotype;

namespace Hipica.Services.File
{
    [Service]
    public class FileSystemCache : IFileSystemCache
    {
        public byte[] Read(FileInfo fileInfo)
        {
            return null;
        }

        public void Write(FileInfo fileInfo, byte[] contents)
        {
        }
    }
}