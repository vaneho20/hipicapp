using Hipicapp.Model.Abstract;
using Hipicapp.Utils.Validator;
using Newtonsoft.Json;
using System;

namespace Hipicapp.Model.Authentication
{
    [JsonObject]
    public class RefreshToken : Entity<string>
    {
        [SafeHtml(WhiteListType.NONE)]
        public virtual string Subject { get; set; }

        [SafeHtml(WhiteListType.NONE)]
        public virtual string ClientId { get; set; }

        public virtual DateTime? IssuedUtc { get; set; }

        public virtual DateTime? ExpiresUtc { get; set; }

        [SafeHtml(WhiteListType.NONE)]
        public virtual string ProtectedTicket { get; set; }
    }

    public class RefreshTokenClassMap : EntityMap<RefreshToken, string>
    {
        public RefreshTokenClassMap()
        {
            Table("AUTHENTICATION_REFRESH_TOKEN");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").Length(50);

            Map(x => x.Subject).Column("SUBJECT").Length(255);
            Map(X => X.ClientId).Column("AUTHENTICATION_CLIENT_ID").Length(255);
            Map(x => x.IssuedUtc).Column("ISSUED_UTC");
            Map(x => x.ExpiresUtc).Column("EXPIRES_UTC");
            Map(x => x.ProtectedTicket).Column("PROTECTED_TICKET").Length(1000);
        }
    }
}