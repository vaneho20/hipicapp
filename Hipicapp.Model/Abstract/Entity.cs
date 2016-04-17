using FluentNHibernate.Mapping;
using Hipicapp.Utils.Comparison;
using Newtonsoft.Json;
using System;

namespace Hipicapp.Model.Abstract
{
    [Serializable]
    [JsonObject]
    public abstract class Entity<K>
    {
        public virtual K Id { get; set; }

        public virtual long? Version { get; set; }

        public virtual bool IsNew
        {
            get
            {
                return null == this.Id;
            }
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;

            Entity<K> other = obj as Entity<K>;

            if (other != null)
            {
                EqualsBuilder builder = new EqualsBuilder();

                builder.Append(this.Id, other.Id);

                isEqual = builder.IsEquals();
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            HashCodeBuilder builder = new HashCodeBuilder();

            builder.Append(this.Id);

            return builder.ToHashCode();
        }

        public override string ToString()
        {
            return ToStringBuilder.ReflectionToString(this);
        }

        public static bool operator ==(Entity<K> left, Entity<K> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<K> left, Entity<K> right)
        {
            return !Equals(left, right);
        }
    }

    public abstract class EntityMap<T, K> : ClassMap<T> where T : Entity<K>
    {
        public EntityMap()
        {
            DynamicUpdate();
            OptimisticLock.Version();

            Version(x => x.Version).Column("VERSION").CustomType<long>().Access.Property().Generated.Always().Not.Nullable().Default("0").UnsavedValue("0");
        }
    }
}