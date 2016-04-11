using Hipica.Model.File;
using Hipica.Model.Participant;
using Hipica.Utils.Pager;

namespace Hipica.Service.Participant
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