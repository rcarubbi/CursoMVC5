using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvaliadorGastronomico.WebUI.Filters;
using AvaliadorGastronomico.WebUI.Models;
using AvaliadorGastronomico.WebUI.ServiceClients;

namespace AvaliadorGastronomico.WebUI.Controllers
{
    [TrackElapsedTime]
    public class InfoController : AsyncController
    {
        //
        // GET: /Info/
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
            return View(model);
        }
    }
}
