using FluentNHibernate.Mapping;
using Hipicapp.Model.Abstract;
using Hipicapp.Model.Account;
using Hipicapp.Model.File;
using Hipicapp.Utils.Util;
using Hipicapp.Utils.Validator;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;
using NSoup.Safety;
using System;
using Unne.Utils.Date;

namespace Hipicapp.Model.Participant
{
    [JsonObject]
    public class Horse : Entity<long?>
    {
        public virtual long? PhotoId { get; set; }

        [NotNull]
        [NotEmpty]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(Whitelist.None)]
        public virtual string Name { get; set; }

        [NotNull]
        [Min(0)]
        public virtual float? Height { get; set; }

        [NotNull]
        [Past]
        public virtual DateTime? BirthDate { get; set; }

        [NotNull]
        public virtual Gender? Gender { get; set; }

        [NotNull]
        [Min(0)]
        public virtual float? Weight { get; set; }

        public virtual FileInfo Photo { get; set; }

        public virtual long? AthleteId { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual long? Age
        {
            get
            {
                return DateUtils.GetAgeExactInYears(this.BirthDate);
            }
        }
    }

    public class HorseMap : EntityMap<Horse, long?>
    {
        public HorseMap()
        {
            Table("HORSE");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").GeneratedBy.Native();

            Map(x => x.PhotoId).Column("PHOTO_ID");
            Map(x => x.Name).Column("NAME");
            Map(x => x.Height).Column("HEIGHT");
            Map(x => x.BirthDate).Column("BIRTH_DATE");
            Map(x => x.Gender).Column("GENDER").CustomType<GenericEnumMapper<Gender>>().Not.Nullable();
            Map(x => x.Weight).Column("WEIGHT").Not.Nullable();
            Map(x => x.AthleteId).Column("ATHLETE_ID");

            References<FileInfo>(x => x.Photo).Column("PHOTO_ID").NotFound.Ignore().LazyLoad().Fetch.Join().ReadOnly();
            References<Athlete>(x => x.Athlete).Column("ATHLETE_ID").Fetch.Join().Not.LazyLoad().ReadOnly();
        }
    }
}