using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AvaliadorGastronomico.WebUI.Infrastructure;
using AvaliadorGastronomico.Domain;
using AvaliadorGastronomico.Domain.Queries;
using Microsoft.Security.Application;
namespace AvaliadorGastronomico.WebUI.Controllers
{
    #region Slide 19
    /*public class CriticaController : Controller
    {
        private AvaliadorGastronomicoDbContext _db = new AvaliadorGastronomicoDbContext();
        public ActionResult Index()
        {
            var model = _db.Criticas.RecuperarMaisRecentes(3);
            return View(model);
        }

        #region Slide 29
        [ChildActionOnly]
        public ActionResult ExibirMelhorCritica()
        {
            var model = _db.Criticas.ProcurarMelhorCritica();
            return PartialView("_Critica", model);
        }
        #endregion

        #region Slide 34
        //
        // GET: /Critica/Criar

        public ActionResult Criar()
        {
            return View(new Critica());
        }

        //
        // POST: /Critica/Create

        [HttpPost]
        public ActionResult Criar(int idRestaurante, Critica novaCritica)
        {
            try
            {
                // novaCritica.Corpo = Sanitizer.GetSafeHtmlFragment(novaCritica.Corpo); // Slide 57
                novaCritica.DataCriacao = DateTime.Now;
                _db.Restaurantes.Single(r => r.Id == idRestaurante).Criticas.Add(novaCritica);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(novaCritica);
            }
        }
        #endregion

        #region Slide 26
        public ActionResult Editar(int id)
        {
            var critica = _db.Criticas.FindById(id);
            return View(critica);
        }
        #endregion

        #region Slide 55
        //
        // GET: /Critica/Editar/5
        public ActionResult Editar(int id)
        {
            var critica = _db.Criticas.FindById(id);
            return View(critica);
        }

        #region Slide 36
        //
        // POST: /Critica/Editar/5

        #region slide 55.2
        [ValidateInput(false)]
        #endregion
        #region Slide 58
        [ValidateAntiForgeryToken]
        #endregion
        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
        {

            var critica = _db.Criticas.FindById(id);

            if (TryUpdateModel(critica))
            {
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(critica);
        }
        #endregion

        #region Slide 55.4
        [HttpPost]
        #region Slide 58
        [ValidateAntiForgeryToken]
        #endregion
        public ActionResult Editar(Critica criticaAtualizada)
        {
            if (ModelState.IsValid)
            {
                // criticaAtualizada.Corpo = Sanitizer.GetSafeHtmlFragment(criticaAtualizada.Corpo); // Slide 57
                _db.Entry(criticaAtualizada).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(criticaAtualizada);
        }

        #endregion

        #endregion
    }*/
    #endregion
}
