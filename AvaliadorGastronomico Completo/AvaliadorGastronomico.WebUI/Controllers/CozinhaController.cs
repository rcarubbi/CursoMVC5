using AvaliadorGastronomico.WebUI.Infrastructure;
using System;
using System.Web.Mvc;

namespace AvaliadorGastronomico.WebUI.Controllers
{
    [Log]
    public class CozinhaController : Controller
    {

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Pesquisar(string nome = "*")
        {
            return Content(nome);
        }

    }
}