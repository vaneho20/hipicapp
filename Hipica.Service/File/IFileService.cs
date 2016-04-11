using Hipica.Model.File;

namespace Hipica.Services.File
{
    public interface IFileService
    {
        FileInfo Get(long? id);

        FileInfo GetContentsByUuid(string fileUuid);

        FileInfo Save(/*Path Path*/);

        FileInfo Save(string name, string mimeType, byte[] contents);

        FileInfo Update(long? id, string name, string mimeType, byte[] contents);

        void Delete(FileInfo model);

        void Delete(long? id);
    }
}