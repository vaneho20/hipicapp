using Hipica.Model.Abstract;
using Hipica.Utils.Comparison;
using Newtonsoft.Json;

namespace Hipica.Model.Participant
{
    [JsonObject]
    public class Score : Entity<ScoreId>
    {
        public virtual float? Value { get; set; }
    }

    public class ScoreMap : EntityMap<Score, ScoreId>
    {
        public ScoreMap()
        {
            Table("SCORE");
            Cache.NonStrictReadWrite();

            CompositeId<ScoreId>(x => x.Id)
                .KeyProperty(x => x.CompetitionId, "COMPETITION_ID")
                .KeyProperty(x => x.HorseId, "HORSE_ID")
                .KeyProperty(x => x.JudgeId, "JUDGE_ID");

            Map(x => x.Value).Column("VALUE_");
        }
    }

    //[ComplexType]
    [JsonObject]
    public class ScoreId
    {
        public ScoreId()
        {
        }

        public ScoreId(long? competitionId, long? horseId, long? judgeId)
        {
            this.CompetitionId = competitionId;
            this.HorseId = horseId;
            this.JudgeId = judgeId;
        }

        public virtual long? CompetitionId { get; set; }

        public virtual long? HorseId { get; set; }

        public virtual long? JudgeId { get; set; }

        public override bool Equals(object obj)
        {
            bool isEqual = false;

            ScoreId other = obj as ScoreId;

            if (other != null)
            {
                EqualsBuilder builder = new EqualsBuilder();

                builder.Append(this.CompetitionId, other.CompetitionId).Append(this.HorseId, other.HorseId).Append(this.JudgeId, other.JudgeId);

                isEqual = builder.IsEquals();
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            HashCodeBuilder builder = new HashCodeBuilder();

            builder.Append(this.CompetitionId).Append(this.HorseId).Append(this.JudgeId);

            return builder.ToHashCode();
        }

        public override string ToString()
        {
            return ToStringBuilder.ReflectionToString(this);
        }
    }
}