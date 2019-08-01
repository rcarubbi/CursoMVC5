using AvaliadorGastronomico.Domain;
using System.Linq;
using System.Web.Mvc;

namespace AvaliadorGastronomico.WebUI.Controllers
{

    public class RestauranteController : Controller
    {
        
        private readonly IDbContext _context;

        public RestauranteController(IDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin")]
        public ActionResult Index(string uf)
        {
            ViewBag.Ufs = _context.Restaurantes.Select(r => r.Endereco.UF).Distinct();
            var query = _context.Restaurantes.Where(r => r.Endereco.UF == uf || uf == null).OrderBy(r => r.Nome);
            return View(query);
        }

        public ActionResult Detalhes(int id)
        {
            var model = _context.Restaurantes.Single(r => r.Id == id);
            return View(model);
        }
    }
}