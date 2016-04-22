using Hipicapp.Filters;
using Hipicapp.Model.Authentication;
using System.Web.Mvc;

namespace Hipicapp.Controllers
{
    public class AdministratorController : Controller
    {
        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public ActionResult Index()
        {
            return View();
        }
    }
}