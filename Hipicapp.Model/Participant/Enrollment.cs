using Hipicapp.Model.Abstract;
using Hipicapp.Model.Event;
using Hipicapp.Utils.Comparison;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;
using System;

namespace Hipicapp.Model.Participant
{
    [JsonObject]
    public class Enrollment : Entity<EnrollmentId>
    {
        public virtual Competition Competition { get; set; }

        public virtual Horse Horse { get; set; }

        [NotNull]
        [Past]
        public virtual DateTime? EnrollmentDate { get; set; }
    }

    public class EnrollmentMap : EntityMap<Enrollment, EnrollmentId>
    {
        public EnrollmentMap()
        {
            Table("ENROLLMENT");
            Cache.NonStrictReadWrite();

            CompositeId<EnrollmentId>(x => x.Id)
                .KeyProperty(x => x.CompetitionId, "COMPETITION_ID")
                .KeyProperty(x => x.HorseId, "HORSE_ID");

            Map(x => x.EnrollmentDate).Column("ENROLLMENT_DATE").Not.Nullable();

            References<Competition>(x => x.Competition).Column("COMPETITION_ID").Fetch.Join().Not.LazyLoad().ReadOnly();
            References<Horse>(x => x.Horse).Column("HORSE_ID").Fetch.Join().Not.LazyLoad().ReadOnly();
        }
    }

    //[ComplexType]
    [JsonObject]
    public class EnrollmentId
    {
        public EnrollmentId()
        {
        }

        public EnrollmentId(long? competitionId, long? horseId)
        {
            this.CompetitionId = competitionId;
            this.HorseId = horseId;
        }

        public virtual long? CompetitionId { get; set; }

        public virtual long? HorseId { get; set; }

        public override bool Equals(object obj)
        {
            bool isEqual = false;

            EnrollmentId other = obj as EnrollmentId;

            if (other != null)
            {
                EqualsBuilder builder = new EqualsBuilder();

                builder.Append(this.CompetitionId, other.CompetitionId).Append(this.HorseId, other.HorseId);

                isEqual = builder.IsEquals();
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            HashCodeBuilder builder = new HashCodeBuilder();

            builder.Append(this.CompetitionId).Append(this.HorseId);

            return builder.ToHashCode();
        }

        public override string ToString()
        {
            return ToStringBuilder.ReflectionToString(this);
        }
    }
}