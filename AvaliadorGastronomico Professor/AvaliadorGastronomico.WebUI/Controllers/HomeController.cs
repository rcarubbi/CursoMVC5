using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AvaliadorGastronomico.WebUI.Infrastructure;
using AvaliadorGastronomico.Domain.Queries;
using AvaliadorGastronomico.Domain;
using AvaliadorGastronomico.WebUI.Models;
namespace AvaliadorGastronomico.WebUI.Controllers
{
    /*public class HomeController : Controller
    {
        public ViewResult Index()
        {
            #region Slide 5.2
            ViewBag.Message = "Bem Vindo";
            return View();
            #endregion

            #region Slide 5.3 a
            var model = new { Mensagem = "Bem Vindo" };
            return View(model);
            #endregion 

            
            #region Slide 5.3 b
            var model = new Mensagens { BoasVindas = "Bem Vindo" };
            return View(model);
            #endregion 
            
        }
        
        #region Slide 41
        private AvaliadorGastronomicoDbContext _db = new AvaliadorGastronomicoDbContext();
        public PartialViewResult ExibirUltimaCritica()
        {
            Thread.Sleep(2000);
            var model = _db.Criticas.RecuperarMaisRecentes(1).SingleOrDefault();
            return PartialView("_Critica", model);
        }
        #endregion 

        #region Slide 44
        #region Slide 60 - a
        //[OutputCache(Duration = 60, VaryByParam = "none")]
        #endregion
        #region Slide 60 - b
        //[OutputCache(Duration=60, VaryByParam="q")]
        #endregion
        #region Slide 62
        //[OutputCache(CacheProfile = "longo", VaryByParam = "q")]
        #endregion
        #region Slide 64
        [OutputCache(CacheProfile = "longo", VaryByParam = "q", VaryByHeader = "Accept-Language")]
        #endregion
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

        #region Slide 45
        public ActionResult SugerirRestaurantes(string term)
        {
            var restaurantes = _db.Restaurantes
                                    .Where(r => r.Nome.Contains(term))
                                    .Take(10)
                                    .Select(r => new { label = r.Nome });

            return Json(restaurantes, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Slide 47
        public ActionResult BuscarRestaurantesJson(string q2)
        {
            Thread.Sleep(2000);

            var restaurantes = _db.Restaurantes
                .Where(r => r.Nome.Contains(q2) || string.IsNullOrEmpty(q2))
                .Take(10)
                .Select(r => new { r.Nome, r.Endereco.Cidade, r.Endereco.UF });

            return Json(restaurantes, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Slide 60
        [OutputCache(Duration = 10, VaryByParam = "none")]
        public PartialViewResult ActionFilha()
        {
            return PartialView();
        }
        #endregion


    }*/
}
