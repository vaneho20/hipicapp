using Hipica.Model.File;
using Hipica.Model.Participant;
using Hipica.Repository.Participant;
using Hipica.Services.File;
using Hipica.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;

namespace Hipica.Service.Participant
{
    [Service]
    public class JudgeService : IJudgeService
    {
        [Autowired]
        private IJudgeRepository JudgeRepository { get; set; }

        [Autowired]
        private IScoreRepository ScoreRepository { get; set; }

        [Autowired]
        private IFileService FileService { get; set; }

        [Transaction(ReadOnly = true)]
        public Page<Judge> Paginated(JudgeFindFilter filter, PageRequest pageRequest)
        {
            return this.JudgeRepository.Paginated(JudgeRepository.GetAllQueryable(), pageRequest);
        }

        [Transaction(ReadOnly = true)]
        public Judge Get(long? id)
        {
            return this.JudgeRepository.Get(id);
        }

        [Transaction]
        public Judge Save(Judge judge)
        {
            judge.Id = null;
            judge.Id = this.JudgeRepository.Save(judge);
            return judge;
        }

        [Transaction]
        public Judge Update(Judge judge)
        {
            var model = this.JudgeRepository.Get(judge.Id);
            model.Name = judge.Name;
            model.Surnames = judge.Surnames;
            this.JudgeRepository.Update(model);
            return model;
        }

        [Transaction]
        public Judge Delete(Judge judge)
        {
            this.JudgeRepository.Delete(this.JudgeRepository.Get(judge.Id));
            return judge;
        }

        [Transaction]
        public FileInfo Upload(Judge judge, string name, string mimeType, byte[] bytes)
        {
            long? previousPhotoId = judge.PhotoId;

            FileInfo newPhotoFileInfo = this.FileService.Save(name, mimeType, bytes);

            judge.PhotoId = newPhotoFileInfo.Id;
            judge.Photo = newPhotoFileInfo;

            this.JudgeRepository.Update(judge);

            if (previousPhotoId != null)
            {
                this.FileService.Delete(previousPhotoId);
            }

            return newPhotoFileInfo;
        }
    }
}