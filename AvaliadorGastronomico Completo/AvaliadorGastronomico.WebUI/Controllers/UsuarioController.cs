using System.Web.Mvc;

namespace AvaliadorGastronomico.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuarioController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}