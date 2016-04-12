using Hipicapp.Model.File;
using Spring.Stereotype;

namespace Hipicapp.Services.File
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