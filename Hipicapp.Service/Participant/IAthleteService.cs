using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;

namespace Hipicapp.Service.Participant
{
    public interface IAthleteService
    {
        Page<Athlete> Paginated(AthleteFindFilter filter, PageRequest pageRequest);

        Athlete Get(long? id);

        Athlete GetByUserId(long? userId);

        Athlete Save(Athlete athlete);

        Athlete Update(Athlete athlete);

        Athlete Delete(Athlete athlete);

        EnrollmentId Inscription(EnrollmentId id);

        FileInfo Upload(Athlete athlete, string name, string mimeType, byte[] bytes);
    }
}