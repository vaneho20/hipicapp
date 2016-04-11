using Hipica.Model.Authentication;
using Hipica.Repository.Abstract;
using Spring.Stereotype;

namespace Hipica.Repository.Authentication
{
    [Repository]
    public class ClientRepository : EntityRepository<Client, string>, IClientRepository
    {
    }
}