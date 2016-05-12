using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Repository.Event;
using Hipicapp.Repository.Participant;
using Hipicapp.Services.File;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System.Linq;

namespace Hipicapp.Service.Participant
{
    [Service]
    public class JudgeService : IJudgeService
    {
        [Autowired]
        private IJudgeRepository JudgeRepository { get; set; }

        [Autowired]
        private IScoreRepository ScoreRepository { get; set; }

        [Autowired]
        private ISeminaryRepository SeminaryRepository { get; set; }

        [Autowired]
        public ISpecialtyRepository SpecialtyRepository { get; set; }

        [Autowired]
        private IFileService FileService { get; set; }

        [Transaction(ReadOnly = true)]
        public Page<Judge> Paginated(JudgeFindFilter filter, PageRequest pageRequest)
        {
            return this.JudgeRepository.Paginated(JudgePredicates.ValueOf(filter, this.JudgeRepository.GetAllQueryable()), pageRequest);
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
            judge.Specialty = this.SpecialtyRepository.Get(judge.SpecialtyId);
            judge.SpecialtyId = judge.Specialty.Id;
            return judge;
        }

        [Transaction]
        public Judge Update(Judge judge)
        {
            var model = this.JudgeRepository.Get(judge.Id);
            model.Name = judge.Name;
            model.Surnames = judge.Surnames;
            model.Gender = judge.Gender;
            model.Federation = judge.Federation;
            model.ZipCode = judge.ZipCode;
            model.PlaceId = judge.PlaceId;
            model.Specialty = this.SpecialtyRepository.Get(judge.SpecialtyId);
            model.SpecialtyId = model.Specialty.Id;
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

        [Transaction(ReadOnly = true)]
        public Page<Judge> FindByWithAssignment(JudgeFindFilter filter, PageRequest pageRequest)
        {
            var page = this.JudgeRepository.Paginated(JudgePredicates.ValueOf(filter, this.JudgeRepository.GetAllQueryable()), pageRequest);

            page.Content.ToList().ForEach(x =>
            {
                x.Assign = this.SeminaryRepository.GetAllQueryable().Any(y => y.Id.JudgeId == x.Id && y.Id.CompetitionId == filter.CompetitionId);
            });

            return page;
        }
    }
}