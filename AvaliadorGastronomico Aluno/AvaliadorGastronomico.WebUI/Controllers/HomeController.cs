using AvaliadorGastronomico.Domain;
using AvaliadorGastronomico.Domain.Queries;
using AvaliadorGastronomico.WebUI.Infrastructure;
using AvaliadorGastronomico.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AvaliadorGastronomico.WebUI.Controllers
{
    public class HomeController : Controller
    {
        #region slide 50
        [Authorize]
        #endregion
        public ViewResult Index()
        {
            var model = new Mensagens { BoasVindas = "Bem Vindo" };
            return View(model);
        }

        private AvaliadorGastronomicoDbContext _db = new AvaliadorGastronomicoDbContext();
        public PartialViewResult ExibirUltimaCritica()
        {
            Thread.Sleep(2000);
            var model = _db.Criticas.RecuperarMaisRecentes(1).SingleOrDefault();
            return PartialView("_Critica", model);
        }

        #region Slide 44
        public PartialViewResult BuscarRestaurantes(string q)
        {
            Thread.Sleep(2000);

            IEnumerable<Restaurante> restaurantes = null;

            if (string.IsNullOrEmpty(q))
            {
                restaurantes = new List<Restaurante>();
            }
            else
            {

                restaurantes = _db.Restaurantes
                    .Where(r => r.Nome.Contains(q) || string.IsNullOrEmpty(q))
                    .Take(10);
            }
            return PartialView("_ResultadoBuscaRestaurantes", restaurantes);
        }
        #endregion

        public ActionResult SugerirRestaurantes(string term)
        {
            var restaurantes = _db.Restaurantes
                                    .Where(r => r.Nome.Contains(term))
                                    .Take(10)
                                    .Select(r => new { label = r.Nome });

            return Json(restaurantes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuscarRestaurantesJson(string q2)
        {
            Thread.Sleep(2000);

            var restaurantes = _db.Restaurantes
                .Where(r => r.Nome.Contains(q2) || string.IsNullOrEmpty(q2))
                .Take(10)
                .Select(r => new { r.Nome, r.Endereco.Cidade, r.Endereco.UF });

            return Json(restaurantes, JsonRequestBehavior.AllowGet);
        }


    }
}
