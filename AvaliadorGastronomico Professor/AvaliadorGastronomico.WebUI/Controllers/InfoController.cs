using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AvaliadorGastronomico.WebUI.Filters;
using AvaliadorGastronomico.WebUI.Models;
using AvaliadorGastronomico.WebUI.ServiceClients;

namespace AvaliadorGastronomico.WebUI.Controllers
{
    [TrackElapsedTime]
    public class InfoController : Controller
    {
        //
        // GET: /Info/ 
        #region Primeiro Passo - Modelo Síncrono
       /* public ActionResult Index()
        {
            var model = new InfoViewModel();
            
            var noticiasClient = new NoticiaServiceClient();
            var tempoClient = new TempoServiceClient();

            model.MancheteDoDia = noticiasClient.RecuperarManchete();
            model.Temperatura = tempoClient.RecuperarPrevisao();


            return View(model);
        }*/
        #endregion

        #region Segundo Passo - Modelo assíncrono não paralelo
       /* public async Task<ActionResult> Index()
        {
            var model = new InfoViewModel();

            var noticiasClient = new NoticiaServiceClient();
            var tempoClient = new TempoServiceClient();

            model.MancheteDoDia = await noticiasClient.RecuperarMancheteAsync();
            model.Temperatura = await tempoClient.RecuperarPrevisaoAsync();

            return View(model);
        }*/
        #endregion

        #region Terceiro Passo - Tentando transformar em um modelo paralelo
        /*public async Task<ActionResult> Index()
        {
            var model = new InfoViewModel();

            RecuperarManchete(model);
            RecuperarTemperatura(model);
            return View(model);
        }

        async Task RecuperarTemperatura(InfoViewModel model)
        {
            var tempoClient = new TempoServiceClient();
            model.Temperatura = await tempoClient.RecuperarPrevisaoAsync();
        }

        async Task RecuperarManchete(InfoViewModel model)
        {
            var noticiasClient = new NoticiaServiceClient();
            model.MancheteDoDia = await noticiasClient.RecuperarMancheteAsync();
        }*/

        #endregion

        #region Quarto Passo - Corrigindo o problema

        /*[AsyncTimeout(1200)]
        [HandleError(ExceptionType=typeof(TimeoutException), View="Timeout")]
        public async Task<ActionResult> Index()
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
        }

        async Task RecuperarManchete(InfoViewModel model)
        {
            var noticiasClient = new NoticiaServiceClient();
            model.MancheteDoDia = await noticiasClient.RecuperarMancheteAsync();
        }*/
        #endregion

        #region Quinto Passo Tratando Exceções
        [AsyncTimeout(3000)]
        [HandleError(ExceptionType=typeof(TimeoutException), View="Timeout")]
        public async Task<ActionResult> Index(CancellationToken tkn)
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
        #endregion
    }
}
