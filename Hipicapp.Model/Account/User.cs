using FluentNHibernate.Mapping;
using Hipicapp.Model.Abstract;
using Hipicapp.Model.Authentication;
using Hipicapp.Utils.Util;
using Hipicapp.Utils.Validator;
using Newtonsoft.Json;
using NHibernate.Validator.Constraints;
using NSoup.Safety;
using System.Collections.Generic;

namespace Hipicapp.Model.Account
{
    [ValidUser]
    [JsonObject]
    public class User : Entity<long?>
    {
        [NotNull]
        [NotEmpty]
        [Email]
        [Size(Max = ValidationUtils.MAX_LENGTH_DEFAULT)]
        [SafeHtml(Whitelist.None)]
        public virtual string UserName { get; set; }

        [NotNull]
        public virtual bool? Enabled { get; set; }

        [NotNull]
        public virtual bool? CredentialsNonExpired { get; set; }

        [NotNull]
        public virtual bool? AccountNonExpired { get; set; }

        [NotNull]
        public virtual bool? AccountNonLocked { get; set; }

        [JsonIgnore]
        [SafeHtml(Whitelist.None)]
        public virtual string Password { get; set; }

        [SafeHtml(Whitelist.None)]
        public virtual string OldPassword { get; set; }

        [SafeHtml(Whitelist.None)]
        public virtual string NewPassword { get; set; }

        [SafeHtml(Whitelist.None)]
        public virtual string ConfirmNewPassword { get; set; }

        [SafeHtml(Whitelist.None)]
        public virtual string PasswordRecoveryHash { get; set; }

        public virtual ISet<Rol> Roles { get; set; }
    }

    public class UserMap : EntityMap<User, long?>
    {
        public UserMap()
        {
            Table("USER");
            Cache.NonStrictReadWrite().IncludeAll();

            Id(x => x.Id).Column("ID").GeneratedBy.Native();

            Map(x => x.UserName).Unique().Column("USER_NAME").Not.Nullable();
            Map(x => x.Enabled).Column("ENABLED");
            Map(x => x.CredentialsNonExpired).Column("CREDETIALS_NON_EXPIRED");
            Map(x => x.AccountNonExpired).Column("ACCOUNT_NON_EXPIRED");
            Map(x => x.AccountNonLocked).Column("ACCOUNT_NON_LOCKED");
            Map(x => x.Password).Column("PASSWORD_").Not.Nullable();
            Map(x => x.PasswordRecoveryHash).Column("PASSWORD_RECOVERY_HASH");

            HasMany(x => x.Roles).Table("USER_AUTHORITY").KeyColumn("USER_ID")
                .Element("AUTHORITY", e => e.Type<GenericEnumMapper<Rol>>()).Not.LazyLoad().Fetch.Join()
                .Cascade.AllDeleteOrphan().AsSet();
        }
    }
}