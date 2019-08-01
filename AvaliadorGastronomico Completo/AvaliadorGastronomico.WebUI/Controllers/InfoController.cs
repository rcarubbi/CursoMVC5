using AvaliadorGastronomico.WebUI.Infrastructure;
using AvaliadorGastronomico.WebUI.Models;
using AvaliadorGastronomico.WebUI.ServiceClient;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AvaliadorGastronomico.WebUI.Controllers
{
    [TrackElapsedTime]
    public class InfoController : Controller
    {
        [AsyncTimeout(3000)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "Timeout")]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var model = new InfoViewModel();
            var task1 = RecuperarManchete(model);
            var task2 = RecuperarTemperatura(model);
            await Task.WhenAll(task1, task2);
           
            return View(model);
        }

        async Task RecuperarTemperatura(InfoViewModel model)
        {
            var tempoClient = new TempoServiceClient();
            model.Temperatura = await tempoClient.RecuperarPrevisaoAsync();
            throw new Exception("Sem dados");
        }

        async Task RecuperarManchete(InfoViewModel model)
        {
            var noticiasClient = new NoticiaServiceClient();
            model.MancheteDoDia = await noticiasClient.RecuperarMancheteAsync();
            throw new Exception("Sem dados");
        }
    }
}