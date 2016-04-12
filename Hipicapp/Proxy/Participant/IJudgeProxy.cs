using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;

namespace Hipicapp.Proxy.Participant
{
    public interface IJudgeProxy
    {
        Page<Judge> Paginated(JudgeFindRequest request);

        Judge Get(long? id);

        Judge Save(Judge athlete);

        Judge Update(Judge athlete);

        Judge Delete(Judge athlete);

        FileInfo Upload(long? id, FileInfo file);
    }
}