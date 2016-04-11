using Hipica.Model.File;
using Hipica.Model.Participant;
using Hipica.Utils.Pager;

namespace Hipica.Proxy.Participant
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