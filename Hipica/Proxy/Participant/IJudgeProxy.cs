using Hipica.Model.Event;
using Hipica.Model.File;
using Hipica.Model.Participant;
using Hipica.Utils.Pager;
using System.Collections.Generic;

namespace Hipica.Proxy.Participant
{
    public interface IJudgeProxy
    {
        Page<Judge> Paginated(JudgeFindRequest request);

        Judge Get(long? id);

        Judge Save(Judge athlete);

        Judge Update(Judge athlete);

        Judge Delete(Judge athlete);

        IList<Score> SimulateScore(Competition competition);

        FileInfo Upload(long? id, FileInfo file);
    }
}