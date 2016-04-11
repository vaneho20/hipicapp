using Hipica.Model.Authentication;
using Hipica.Utils.Pager;
using System.Collections.Generic;

namespace Hipica.Proxy.Authentication
{
    public interface IClientProxy
    {
        Client Get(string id);

        IList<Client> GetAll();

        Page<Client> Paginated(PageRequest pageRequest);

        string Save(Client entity);

        void Save(IList<Client> entity);

        void Update(Client entity);
    }
}