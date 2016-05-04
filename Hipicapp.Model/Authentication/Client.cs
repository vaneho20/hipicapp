using Hipicapp.Model.Abstract;
using Hipicapp.Utils.Validator;
using Newtonsoft.Json;
using NSoup.Safety;

namespace Hipicapp.Model.Authentication
{
    [JsonObject]
    public class Client : Entity<string>
    {
        [SafeHtml(Whitelist.None)]
        public virtual string Secret { get; set; }

        [SafeHtml(Whitelist.None)]
        public virtual string Name { get; set; }

        public virtual ApplicationTypes ApplicationType { get; set; }

        public virtual bool Active { get; set; }

        public virtual int RefreshTokenLifeTime { get; set; }

        [SafeHtml(Whitelist.None)]
        public virtual string AllowedOrigin { get; set; }
    }

    public class ClientClassMap : EntityMap<Client, string>
    {
        public ClientClassMap()
        {
            Table("AUTHENTICATION_CLIENT");
            Cache.NonStrictReadWrite();

            Id(x => x.Id).Column("ID").Length(50);

            Map(x => x.Secret).Column("SECRET").Length(255);
            Map(x => x.Name).Column("NAME").Length(255);
            Map(x => x.ApplicationType).Column("APPLICATION_TYPE").Length(10);
            Map(x => x.Active).Column("ACTIVE");
            Map(x => x.RefreshTokenLifeTime).Column("REFRESH_TOKEN_LIFETIME");
            Map(x => x.AllowedOrigin).Column("ALLOWED_ORIGIN").Length(255);
        }
    }
}