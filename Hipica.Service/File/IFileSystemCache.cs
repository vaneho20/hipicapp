using Hipica.Model.File;

namespace Hipica.Services.File
{
    public interface IFileSystemCache
    {
        byte[] Read(FileInfo fileInfo);

        void Write(FileInfo fileInfo, byte[] contents);
    }
}