using AvaliadorGastronomico.WebUI.Infrastructure;
using AvaliadorGastronomico.WebUI.Models;
using AvaliadorGastronomico.WebUI.ServiceClient;
using System.Web.Mvc;

namespace AvaliadorGastronomico.WebUI.Controllers
{
    [TrackElapsedTime]
    public class MVC3InfoController : AsyncController
    {
        public void IndexAsync()
        {

            var model = new InfoViewModel();

            var noticiasClient = new NoticiaServiceClient();
            var tempoClient = new TempoServiceClient();

            AsyncManager.Parameters["model"] = model;

            AsyncManager.OutstandingOperations.Increment();
            noticiasClient.BeginRecuperarManchetes(ar =>
            {
                model.MancheteDoDia = noticiasClient.EndRecuperarManchetes(ar);
                AsyncManager.OutstandingOperations.Decrement();
            }, null);

            AsyncManager.OutstandingOperations.Increment();
            tempoClient.BeginRecuperarPrevisao(ar =>
            {
                model.Temperatura = tempoClient.EndRecuperarPrevisao(ar);
                AsyncManager.OutstandingOperations.Decrement();
            }, null);
        }

        public ViewResult IndexCompleted(InfoViewModel model)
        {
            return View("~/Views/Info/Index.cshtml", model);
        }
    }
}