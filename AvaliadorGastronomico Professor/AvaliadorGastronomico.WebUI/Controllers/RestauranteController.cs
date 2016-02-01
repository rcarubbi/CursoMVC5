using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvaliadorGastronomico.WebUI.Infrastructure;
using AvaliadorGastronomico.Domain;
using AvaliadorGastronomico.Domain.Queries;
namespace AvaliadorGastronomico.WebUI.Controllers
{

    #region Slide 32
    /*public class RestauranteController : Controller
    {
        private AvaliadorGastronomicoDbContext _db = new AvaliadorGastronomicoDbContext();

        #region Slide 52
        [Authorize(Roles = "admin")]
        #endregion 
        public ActionResult Index(string uf)
        {
            ViewBag.Ufs = _db.Restaurantes.Select(r => r.Endereco.UF).Distinct();
            var query = _db.Restaurantes.Where(r => r.Endereco.UF == uf || uf == null).OrderBy(r => r.Nome);
            return View(query);
        }

        public ActionResult Detalhes(int id)
        {
            var model = _context.Restaurantes.Single(r => r.Id == id);
            return View(model);
        }
    } */
    #endregion
   
  
}
