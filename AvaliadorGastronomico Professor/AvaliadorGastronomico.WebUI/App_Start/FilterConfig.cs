using System.Web;
using System.Web.Mvc;

namespace AvaliadorGastronomico.WebUI
{
    // slide 15
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}