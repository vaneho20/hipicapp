using Editorial.Service.Model.Store;
using FluentNHibernate.Mapping;

namespace Editorial.Service.Model.Account
{
    public class UserProfileMap : ClassMap<UserProfile>
    {
        public UserProfileMap()
        {
            Table("USER_PROFILE");

            Id(x => x.UserId);

            Map(x => x.RealName).Column("REAL_NAME");
            Map(x => x.UserName).Unique().Column("USER_NAME");
            Map(x => x.Gender).Column("GENDER");
            Map(x => x.DateOfBirth).Column("DATE_OF_BIRTH");
            Map(x => x.Country).Column("COUNTRY");
            Map(x => x.MobilePhoneNumber).Column("MOBILE_PHONE_NUMBER");
            Map(x => x.NotifyNewsRecommendationsSuggestions).Column("NOTIFY_NEWS_RECOMMENDATIONS_SUGGESTIONS");
            Map(x => x.NotifyRepertoireSubscriptions).Column("NOTIFY_REPERTOIRE_SUBSCRIPTIONS");
            Map(x => x.NotifyNewInvitations).Column("NOTIFY_NEW_INVITATIONS");

            References<Instrument>(x => x.MainInstrument).Column("MAIN_INSTRUMENT_ID").Not.LazyLoad();
            References<Instrument>(x => x.SecondaryInstrument1).Column("SECONDARY_INSTRUMENT1_ID").LazyLoad();
            References<Instrument>(x => x.SecondaryInstrument2).Column("SECONDARY_INSTRUMENT2_ID").LazyLoad();
            References<Instrument>(x => x.SecondaryInstrument3).Column("SECONDARY_INSTRUMENT3_ID").LazyLoad();

            HasMany<Repertoire>(x => x.Repertoires).KeyColumn("UserId").LazyLoad();
            HasMany<Subscription>(x => x.Subscriptions)
                .KeyColumn("UserId")
                .Cascade.All()
                .OrderBy("SubscriptionDate DESC")
                .LazyLoad();
        }
    }
}