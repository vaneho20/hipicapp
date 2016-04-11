using Hipica.Repository.Authentication;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;

namespace Hipica.Service.Authentication
{
    [Service]
    [Transaction(ReadOnly = true)]
    public class ClientService : IClientService
    {
        [Autowired]
        private IClientRepository clientRepository { get; set; }

        [Transaction(ReadOnly = false)]
        public string Save(Model.Authentication.Client entity)
        {
            return clientRepository.Save(entity);
        }

        [Transaction(ReadOnly = false)]
        public void Save(IList<Model.Authentication.Client> entity)
        {
            clientRepository.Save(entity);
        }

        [Transaction(ReadOnly = false)]
        public void Update(Model.Authentication.Client entity)
        {
            clientRepository.Update(entity);
        }

        public Model.Authentication.Client Get(string id)
        {
            return clientRepository.Get(id);
        }

        public IList<Model.Authentication.Client> GetAll()
        {
            return clientRepository.GetAll();
        }

        public Utils.Pager.Page<Model.Authentication.Client> Paginated(Utils.Pager.PageRequest pageRequest)
        {
            return clientRepository.Paginated(pageRequest);
        }
    }
}