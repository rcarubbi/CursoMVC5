using System.Diagnostics;
using System.Web.Mvc;

namespace AvaliadorGastronomico.WebUI.Infrastructure
{
    public class TrackElapsedTimeAttribute : ActionFilterAttribute
    {
        public TrackElapsedTimeAttribute()
        {
            Order = int.MaxValue;
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
                    controller.ViewBag.ElapsedTime = timer.ElapsedMilliseconds;
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}