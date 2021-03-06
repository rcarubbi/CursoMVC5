﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AvaliadorGastronomico.WebUI.Infrastructure;

namespace AvaliadorGastronomico.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {



        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            // slide 72
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            // slide 15
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // slide 67
            BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            // slide 78
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Chrome")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
                ("chrome", StringComparison.OrdinalIgnoreCase) >= 0)
            });
        }
    }
}