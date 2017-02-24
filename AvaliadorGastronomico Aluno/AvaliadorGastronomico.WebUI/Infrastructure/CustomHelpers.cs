using System.Web;
using System.Web.Mvc;

namespace AvaliadorGastronomico.WebUI.Infrastructure
{
    #region Slide 27
    public static class CustomHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText)
        {

            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", new UrlHelper(HttpContext.Current.Request.RequestContext).Content(src));
            builder.MergeAttribute("alt", altText);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
    #endregion
}