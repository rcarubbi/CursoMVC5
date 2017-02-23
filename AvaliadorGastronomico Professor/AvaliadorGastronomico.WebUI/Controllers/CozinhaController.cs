using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvaliadorGastronomico.WebUI.Infrastructure;

namespace AvaliadorGastronomico.WebUI.Controllers
{
    #region Slide 16
    // [Log] 
    #endregion
    #region Slide 14
    //[Authorize] 
    #endregion
    #region Slide 10.1
    public class CozinhaController : Controller
    {
        //
        // GET: /Cozinha/
        #region Slide 10.1
        /*public ActionResult Pesquisar()
        {
            return Content("Você está no controller Cozinha");
        }*/
        #endregion

        #region  Slide 11.1
        /*public ActionResult Pesquisar(string nome)
        {
            var a = ControllerContext.RouteData;
            nome = Server.HtmlEncode(nome);
            return Content(nome);
        }*/
        #endregion

        #region  Slide 11.2
        /* public ActionResult Pesquisar(string nome = "*")
         {
             if (nome == "*")
             {
                 return RedirectToAction("Pesquisar", "Cozinha", new { nome = "francesa" });
             }
             return Content(nome);
         }*/
        #endregion

        #region  Slide 11.2 b
        /* public ActionResult Pesquisar(string nome = "*")
        {
            if (nome == "*")
            {
                return RedirectToRoute("Cozinha", new { nome = "japonesa" });
            }
            return Content(nome);
        }*/
        #endregion

        #region  Slide 12 a
        /*public ActionResult Pesquisar(string nome = "*")
        {
            return RedirectPermanent("http://www.microsoft.com");
        }*/
        #endregion

        // slide 13.1
        //[ActionName("Teste")]
        // slide 13.2
        //[AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        #region  Slide 12 b
        /*public ActionResult Pesquisar(string nome = "*")
        {
            return Json(new { nomeCozinha = nome }, JsonRequestBehavior.AllowGet);
        }*/
        #endregion

        #region  Slide 12 c
        /*public ActionResult Pesquisar(string nome = "*")
        {
            return File(Server.MapPath("~/Content/Site.css"), "text/css");
        }*/
        #endregion

        #region Slide 15
        public ActionResult Pesquisar(string nome = "*") 
        {
            throw new Exception("oops!");
        }
        #endregion 

    }
    #endregion
}
