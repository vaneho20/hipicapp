using Hipicapp.Model.File;
using Hipicapp.Model.Publicity;
using Hipicapp.Repository.Event;
using Hipicapp.Repository.Publicity;
using Hipicapp.Services.File;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hipicapp.Service.Publicity
{
    [Service]
    public class BannerService : IBannerService
    {
        [Autowired]
        private IBannerRepository BannerRepository { get; set; }

        [Autowired]
        public ISpecialtyRepository SpecialtyRepository { get; set; }

        [Autowired]
        private IFileService FileService { get; set; }

        [Transaction(ReadOnly = true)]
        public Page<Banner> Paginated(BannerFindFilter filter, PageRequest pageRequest)
        {
            return this.BannerRepository.Paginated(BannerPredicates.ValueOf(filter, this.BannerRepository.GetAllQueryable()), pageRequest);
        }

        [Transaction(ReadOnly = true)]
        public IList<Banner> FindVisibleBySpecialtyId(long? specialtyId)
        {
            return this.BannerRepository.GetAllQueryable().Where(x => x.Visible.Value).ToList();
        }

        [Transaction(ReadOnly = true)]
        public Banner Get(long? id)
        {
            return this.BannerRepository.Get(id);
        }

        [Transaction]
        public Banner Save(Banner banner)
        {
            banner.Id = null;
            banner.CreationDate = DateTime.Now;
            banner.Specialty = this.SpecialtyRepository.Get(banner.SpecialtyId);
            banner.SpecialtyId = banner.Specialty.Id;
            banner.Id = this.BannerRepository.Save(banner);
            return banner;
        }

        [Transaction]
        public Banner Update(Banner banner)
        {
            var model = this.BannerRepository.Get(banner.Id);
            model.Title = banner.Title;
            model.Web = banner.Web;
            model.Visible = banner.Visible;
            model.Specialty = this.SpecialtyRepository.Get(banner.SpecialtyId);
            model.SpecialtyId = model.Specialty.Id;
            this.BannerRepository.Update(model);
            return model;
        }

        [Transaction]
        public Banner Delete(Banner banner)
        {
            this.BannerRepository.Delete(this.BannerRepository.Get(banner.Id));
            return banner;
        }

        [Transaction]
        public FileInfo Upload(Banner banner, string name, string mimeType, byte[] bytes)
        {
            long? previousImageId = banner.ImageId;

            FileInfo newImageFileInfo = this.FileService.Save(name, mimeType, bytes);

            banner.ImageId = newImageFileInfo.Id;
            banner.Image = newImageFileInfo;

            this.BannerRepository.Update(banner);

            if (previousImageId != null)
            {
                this.FileService.Delete(previousImageId);
            }

            return newImageFileInfo;
        }
    }
}