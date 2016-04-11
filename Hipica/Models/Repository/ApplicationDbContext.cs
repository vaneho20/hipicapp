using Hipica.Backend.Models.Authentication;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Hipica.Backend.Authentication.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public IDbSet<UserSession> UserSessions { get; set; }

        public IDbSet<RefreshToken> RefreshTokens { get; set; }

        public ApplicationDbContext()
            : base("HipicaBackendContext")
        {
        }

        static ApplicationDbContext()
        {
            //Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}