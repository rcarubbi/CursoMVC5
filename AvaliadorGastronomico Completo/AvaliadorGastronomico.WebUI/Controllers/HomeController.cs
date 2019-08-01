using AvaliadorGastronomico.Domain;
using AvaliadorGastronomico.Domain.Queries;
using AvaliadorGastronomico.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace AvaliadorGastronomico.WebUI.Controllers
{

    public class HomeController : Controller
    {
        private readonly IDbContext _context;

        public HomeController(IDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public ViewResult Index()
        {
            ViewBag.Message = "Bem vindo";

            var model = new Mensagens {
                BoasVindas = "Bem Vindo"
            };
            return View(model);
        }


        public PartialViewResult ExibirUltimaCritica()
        {
            Thread.Sleep(2000);
            var model = _context.Criticas.RecuperarMaisRecentes(1).SingleOrDefault();
            return PartialView("_Critica", model);
        }

        [OutputCache(CacheProfile = "longo", VaryByParam = "q", VaryByHeader = "Accept-Language")]
        public PartialViewResult BuscarRestaurantes(string q)
        {
            Thread.Sleep(2000);

            var restaurantes = string.IsNullOrEmpty(q)
                    ? new List<Restaurante>()
                    : _context.Restaurantes
                    .Where(r => r.Nome.Contains(q) || string.IsNullOrEmpty(q))
                    .Take(10).ToList();
             
            return PartialView("_ResultadoBuscaRestaurante", restaurantes);
        }

        public ActionResult SugerirRestaurantes(string term)
        {
            var restaurantes = _context.Restaurantes
                                    .Where(r => r.Nome.Contains(term))
                                    .Take(10)
                                    .Select(r => new { label = r.Nome });

            return Json(restaurantes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuscarRestaurantesJson(string q2)
        {
            Thread.Sleep(2000);

            var restaurantes = _context.Restaurantes
                .Where(r => r.Nome.Contains(q2) || string.IsNullOrEmpty(q2))
                .Take(10)
                .Select(r => new { r.Nome, r.Endereco.Cidade, r.Endereco.UF });

            return Json(restaurantes, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 10, VaryByParam = "none")]
        public PartialViewResult ActionFilha()
        {
            return PartialView();
        }
    }
}
