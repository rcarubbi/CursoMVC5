using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
namespace AvaliadorGastronomico.WebUI.Filters
{
    public class TrackElapsedTimeAttribute : ActionFilterAttribute
    {
        public TrackElapsedTimeAttribute()
        {
            this.Order = int.MaxValue;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller;
            var timer = new Stopwatch();
            controller.ViewBag.ElapsedTimer = timer;
            timer.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.Controller;
            if (controller != null)
            {
                var timer = (Stopwatch)controller.ViewBag.ElapsedTimer;
                if (timer != null)
                {
                    timer.Stop();
                    controller.ViewBag.ElapsedTime  = timer.ElapsedMilliseconds;
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}