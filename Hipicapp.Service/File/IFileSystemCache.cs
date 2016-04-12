using Hipicapp.Model.File;

namespace Hipicapp.Services.File
{
    public interface IFileSystemCache
    {
        byte[] Read(FileInfo fileInfo);

        void Write(FileInfo fileInfo, byte[] contents);
    }
}