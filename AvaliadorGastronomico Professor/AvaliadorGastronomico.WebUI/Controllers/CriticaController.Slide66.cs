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
  
    public class CriticaController : Controller
    {

        private IDbContext _context = null;
        public CriticaController(IDbContext context)
        {
            _context = context;
        }

      
        public ActionResult Index()
        {
            var model = _context.Criticas.RecuperarMaisRecentes(3);
            return View(model);
        }


        [ChildActionOnly]
        public ActionResult ExibirMelhorCritica()
        {
            var model = _context.Criticas.ProcurarMelhorCritica();
            return PartialView("_Critica", model);
        }
     

    
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
                novaCritica.Corpo = Sanitizer.GetSafeHtmlFragment(novaCritica.Corpo);  
                novaCritica.DataCriacao = DateTime.Now;
                _context.Restaurantes.Single(r => r.Id == idRestaurante).Criticas.Add(novaCritica);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(novaCritica);
            }
        }
        
        //
        // GET: /Critica/Editar/5
        public ActionResult Editar(int id)
        {
            var critica = _context.Criticas.FindById(id);
            return View(critica);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Critica criticaAtualizada)
        {
            if (ModelState.IsValid)
            {
                 criticaAtualizada.Corpo = Sanitizer.GetSafeHtmlFragment(criticaAtualizada.Corpo);
                 _context.SetModified(criticaAtualizada);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(criticaAtualizada);
        }

    }
  
}


