using Hipica.Model.File;
using Hipica.Model.Participant;
using Hipica.Utils.Pager;

namespace Hipica.Service.Participant
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