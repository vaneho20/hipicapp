using Hipica.Model.Athlete;
using Hipica.Model.File;
using Hipica.Model.Participant;
using Hipica.Utils.Pager;

namespace Hipica.Proxy.Participant
{
    public interface IAthleteProxy
    {
        Page<Athlete> Paginated(AthleteFindRequest request);

        Athlete Get(long? id);

        Athlete GetByCurrentUser();

        Athlete Save(Athlete athlete);

        Athlete Update(Athlete athlete);

        Athlete Delete(Athlete athlete);

        EnrollmentId Inscription(EnrollmentId id);

        FileInfo Upload(long? id, FileInfo file);
    }
}