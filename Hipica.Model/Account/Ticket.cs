using Hipica.Model.Abstract;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;
using System;

namespace Hipica.Model.Account
{
    [JsonObject]
    public class Ticket : Entity<long?>
    {
        [NotNull]
        [NotEmpty]
        public virtual string Key { get; set; }

        public virtual User User { get; set; }

        public virtual DateTime? CreateDate { get; set; }

        public virtual DateTime? ExpirationDate { get; set; }

        //[NotMapped]
        public virtual bool IsExpired
        {
            get
            {
                if (ExpirationDate != null && DateTime.Compare(ExpirationDate.Value, DateTime.Now) < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    public class TicketMap : EntityMap<Ticket, long?>
    {
        public TicketMap()
        {
            Table("TICKET");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID");

            Map(x => x.CreateDate).Column("CREATE_DATE").Not.Nullable();
            Map(x => x.ExpirationDate).Column("EXPIRATION_DATE");
            Map(x => x.Key).Column("KEY_").Index("IX_KEY_").Not.Nullable().Length(36);

            References<User>(x => x.User).Column("USER_ID").LazyLoad();
        }
    }
}