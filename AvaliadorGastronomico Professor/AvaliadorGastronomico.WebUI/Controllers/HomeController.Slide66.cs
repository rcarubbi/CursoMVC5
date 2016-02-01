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
    public class HomeController : Controller
    {

        private IDbContext _context = null;
        public HomeController(IDbContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            var model = new Mensagens { BoasVindas = "Bem Vindo" };
            return View(model);
        }
        
   
        private AvaliadorGastronomicoDbContext _db = new AvaliadorGastronomicoDbContext();
      

        [OutputCache(CacheProfile = "longo", VaryByParam = "q", VaryByHeader = "Accept-Language")]
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

                restaurantes = _context.Restaurantes
                    .Where(r => r.Nome.Contains(q) || string.IsNullOrEmpty(q))
                    .Take(10);
            }
            return PartialView("_ResultadoBuscaRestaurantes", restaurantes);
        }

    }
}
