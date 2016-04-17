using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;

namespace Hipicapp.Service.Participant
{
    public interface IJudgeService
    {
        Page<Judge> Paginated(JudgeFindFilter filter, PageRequest pageRequest);

        Judge Get(long? id);

        Judge Save(Judge judge);

        Judge Update(Judge judge);

        Judge Delete(Judge judge);

        FileInfo Upload(Judge judge, string name, string mimeType, byte[] bytes);
    }
}