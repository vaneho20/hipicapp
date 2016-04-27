using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;

namespace Hipicapp.Proxy.Participant
{
    public interface IAthleteProxy
    {
        Page<Athlete> Paginated(AthleteFindRequest request);

        Athlete Get(long? id);

        Athlete GetByCurrentUser();

        Athlete Save(Athlete athlete);

        Athlete Register(Athlete athlete);

        Athlete Update(Athlete athlete);

        Athlete Delete(Athlete athlete);

        EnrollmentId Inscription(EnrollmentId id);

        FileInfo Upload(long? id, FileInfo file);
    }
}