using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;

namespace Hipicapp.Proxy.Participant
{
    public interface IHorseProxy
    {
        Page<Horse> Paginated(HorseFindRequest request);

        Horse Get(long? id);

        Horse Save(Horse horse);

        Horse Update(Horse horse);

        Horse Delete(Horse horse);

        FileInfo Upload(long? id, FileInfo file);
    }
}