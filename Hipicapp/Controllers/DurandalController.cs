using Hipicapp.Filters;
using Hipicapp.Model.Authentication;
using System.Web.Mvc;

namespace Hipicapp.Controllers
{
    public class DurandalController : Controller
    {
        [AuthorizeEnum(Rol.ATHLETE)]
        public ActionResult Index()
        {
            return View();
        }
    }
}