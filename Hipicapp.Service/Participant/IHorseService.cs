using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;

namespace Hipicapp.Service.Participant
{
    public interface IHorseService
    {
        Page<Horse> Paginated(HorseFindFilter filter, PageRequest pageRequest);

        Horse Get(long? id);

        Horse Save(Horse horse);

        Horse Update(Horse horse);

        Horse Delete(Horse horse);

        FileInfo Upload(Horse horse, string name, string mimeType, byte[] bytes);
    }
}