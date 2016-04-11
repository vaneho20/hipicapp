using Hipica.Model.File;
using Hipica.Model.Participant;
using Hipica.Utils.Pager;

namespace Hipica.Proxy.Participant
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