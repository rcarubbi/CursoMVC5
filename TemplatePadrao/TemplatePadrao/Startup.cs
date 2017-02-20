using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TemplatePadrao.Startup))]
namespace TemplatePadrao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
