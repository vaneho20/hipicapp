namespace Hipicapp.Backend.Authentication.Repository
{
    using Hipicapp.Backend.Models.Authentication;

    public interface IAdsData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<ApplicationRole> UserRoles { get; }

        IRepository<UserSession> UserSessions { get; }

        int SaveChanges();
    }
}