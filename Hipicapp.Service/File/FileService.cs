using Hipicapp.Model.File;
using Hipicapp.Repositories.File;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System;

namespace Hipicapp.Services.File
{
    [Service]
    public class FileService : IFileService
    {
        [Autowired]
        public IFileInfoRepository FileInfoRepository { get; set; }

        [Autowired]
        public IFileContentRepository FileContentRepository { get; set; }

        [Autowired]
        public IFileSystemCache FileSystemCache;

        [Transaction(ReadOnly = true)]
        public FileInfo GetContentsByUuid(string fileUuid)
        {
            FileInfo fileInfo = this.FileInfoRepository.GetFileUuid(fileUuid);

            if (fileInfo != null)
            {
                byte[] contents = this.FileSystemCache.Read(fileInfo);
                if (contents == null)
                {
                    contents = this.FileContentRepository.Get(fileInfo.Id).Contents;
                    this.FileSystemCache.Write(fileInfo, contents);
                }

                fileInfo.Contents = contents;
            }

            return fileInfo;
        }

        [Transaction(ReadOnly = true)]
        public FileInfo Get(long? id)
        {
            return this.FileInfoRepository.Get(id);
        }

        [Transaction]
        public FileInfo Save(/*Path path*/)
        {
            return null;
            /*try {
                return this.save(path.getFileName().toString(), Files.probeContentType(path), Files.readAllBytes(path));
            } catch (final IOException e) {
                throw new ApplicationRuntimeException(e);
            }*/
        }

        [Transaction]
        public FileInfo Save(string fileName, string contentType, byte[] contents)
        {
            FileInfo fileInfo = new FileInfo();
            fileInfo.FileUuid = Guid.NewGuid().ToString();
            fileInfo.FileName = fileName;
            if (contentType.Contains("image"))
            {
                contentType = contentType.Replace("image", "application");
            }
            fileInfo.ContentType = contentType;
            fileInfo.Id = this.FileInfoRepository.Save(fileInfo);

            FileContent FileContent = new FileContent();
            FileContent.Contents = contents;
            FileContent.FileInfo = fileInfo;
            FileContent.Id = this.FileContentRepository.Save(FileContent);

            return fileInfo;
        }

        [Transaction]
        public FileInfo Update(long? id, string fileName, string contentType, byte[] contents)
        {
            FileInfo fileInfo = this.Get(id);
            fileInfo.FileName = fileName;
            fileInfo.ContentType = contentType;
            this.FileInfoRepository.Update(fileInfo);

            FileContent FileContent = this.FileContentRepository.Get(fileInfo.Id);
            FileContent.Contents = contents;
            FileContent.FileInfo = fileInfo;
            this.FileContentRepository.Save(FileContent);

            return fileInfo;
        }

        [Transaction]
        public void Delete(FileInfo model)
        {
            var content = this.FileContentRepository.Get(model.Id);
            this.FileContentRepository.Delete(content);
            this.FileInfoRepository.Delete(content.FileInfo);
        }

        [Transaction]
        public void Delete(long? id)
        {
            var content = this.FileContentRepository.Get(id);
            this.FileContentRepository.Delete(content);
            this.FileInfoRepository.Delete(content.FileInfo);
        }
    }
}