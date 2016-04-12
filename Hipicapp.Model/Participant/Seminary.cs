using Hipicapp.Model.Abstract;
using Hipicapp.Model.Event;
using Hipicapp.Utils.Comparison;
using Newtonsoft.Json;

namespace Hipicapp.Model.Participant
{
    [JsonObject]
    public class Seminary : Entity<SeminaryId>
    {
        public virtual Competition Competition { get; set; }

        public virtual Judge Judge { get; set; }
    }

    public class SeminaryMap : EntityMap<Seminary, SeminaryId>
    {
        public SeminaryMap()
        {
            Table("SEMINARY");
            Cache.NonStrictReadWrite();

            CompositeId<SeminaryId>(x => x.Id)
                .KeyProperty(x => x.CompetitionId, "COMPETITION_ID")
                .KeyProperty(x => x.JudgeId, "JUDGE_ID");

            References<Competition>(x => x.Competition).Column("COMPETITION_ID").Fetch.Join().LazyLoad().ReadOnly();
            References<Judge>(x => x.Judge).Column("JUDGE_ID").Fetch.Join().LazyLoad().ReadOnly();
        }
    }

    //[ComplexType]
    [JsonObject]
    public class SeminaryId
    {
        public SeminaryId()
        {
        }

        public SeminaryId(long? competitionId, long? judgeId)
        {
            this.CompetitionId = competitionId;
            this.JudgeId = judgeId;
        }

        public virtual long? CompetitionId { get; set; }

        public virtual long? JudgeId { get; set; }

        public override bool Equals(object obj)
        {
            bool isEqual = false;

            SeminaryId other = obj as SeminaryId;

            if (other != null)
            {
                EqualsBuilder builder = new EqualsBuilder();

                builder.Append(this.CompetitionId, other.CompetitionId).Append(this.JudgeId, other.JudgeId);

                isEqual = builder.IsEquals();
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            HashCodeBuilder builder = new HashCodeBuilder();

            builder.Append(this.CompetitionId).Append(this.JudgeId);

            return builder.ToHashCode();
        }

        public override string ToString()
        {
            return ToStringBuilder.ReflectionToString(this);
        }
    }
}