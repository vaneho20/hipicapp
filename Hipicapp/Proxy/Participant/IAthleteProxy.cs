using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hipicapp.Proxy.Participant
{
    public interface IAthleteProxy
    {
        Page<Athlete> Paginated(AthleteFindRequest request);

        Athlete Get(long? id);

        Athlete GetByCurrentUser();

        string GetFullNameByUserId(long? userId);

        Athlete Save(Athlete athlete);

        Task<HttpResponseMessage> Register(Athlete athlete);

        Athlete Update(Athlete athlete);

        Athlete Delete(Athlete athlete);

        EnrollmentId Inscription(EnrollmentId id);

        FileInfo Upload(long? id, FileInfo file);
    }
}