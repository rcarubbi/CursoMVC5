using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AvaliadorGastronomico.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Slide 9
            /*routes.MapRoute("Cozinha", "cozinha/{nome}",
                new { controller = "Cozinha", action = "Pesquisar" }
            );*/
            #endregion

            #region Slide 11.2
            /*routes.MapRoute("Cozinha", "cozinha/{nome}",
                new { controller = "Cozinha", action = "Pesquisar", nome = UrlParameter.Optional }
            );*/
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}