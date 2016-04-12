using Hipicapp.Model.Authentication;
using Hipicapp.Service.Authentication;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using System.Collections.Generic;

namespace Hipicapp.Proxy.Authentication
{
    [Proxy]
    public class ClientProxy : IClientProxy
    {
        [Autowired]
        private IClientService ClientService { get; set; }

        public string Save(Client entity)
        {
            return ClientService.Save(entity);
        }

        public void Save(IList<Client> entity)
        {
            ClientService.Save(entity);
        }

        public void Update(Client entity)
        {
            ClientService.Update(entity);
        }

        public Client Get(string id)
        {
            return ClientService.Get(id);
        }

        public IList<Client> GetAll()
        {
            return ClientService.GetAll();
        }

        public Page<Client> Paginated(PageRequest pageRequest)
        {
            return ClientService.Paginated(pageRequest);
        }
    }
}