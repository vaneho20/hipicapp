using Editorial.Service.Model.Store;
using System;
using System.Collections.Generic;
using UtReMi.Utils.Comparison;

namespace Editorial.Service.Model.Account
{
    public class UserProfile
    {
        public virtual long UserId { get; set; }

        public virtual string RealName { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Gender { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        public virtual string Country { get; set; }

        public virtual string MobilePhoneNumber { get; set; }

        public virtual bool NotifyNewsRecommendationsSuggestions { get; set; }

        public virtual bool NotifyRepertoireSubscriptions { get; set; }

        public virtual bool NotifyNewInvitations { get; set; }

        public virtual Instrument MainInstrument { get; set; }

        public virtual Instrument SecondaryInstrument1 { get; set; }

        public virtual Instrument SecondaryInstrument2 { get; set; }

        public virtual Instrument SecondaryInstrument3 { get; set; }

        public virtual IList<Repertoire> Repertoires { get; set; }

        public virtual IList<Subscription> Subscriptions { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            if (obj == this) { return true; }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            UserProfile user = (UserProfile)obj;
            return new EqualsBuilder().Append(this.UserId, user.UserId).IsEquals();
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder().Append(this.UserId).ToHashCode();
        }
    }
}