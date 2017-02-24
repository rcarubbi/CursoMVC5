using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvaliadorGastronomico.WebUI.Infrastructure;

namespace AvaliadorGastronomico.WebUI.Controllers
{
    #region Slide 16
    [Log] 
    #endregion
    #region Slide 14
    [Authorize] 
    #endregion
    #region Slide 10.1
    public class CozinhaController : Controller
    {
        //
        // GET: /Cozinha/
        #region Slide 10.1
        public ActionResult Pesquisar()
        {
            return Content("Você está no controller Cozinha");
        }
        #endregion

       
        // slide 13.1
        [ActionName("Teste")]
        // slide 13.2
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        #region  Slide 12 b
        public ActionResult Pesquisar(string nome = "*")
        {
            return Json(new { nomeCozinha = nome }, JsonRequestBehavior.AllowGet);
        }
        #endregion

       

    }
    #endregion
}
