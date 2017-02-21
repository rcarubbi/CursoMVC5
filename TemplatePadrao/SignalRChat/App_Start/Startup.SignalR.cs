
using Owin;

namespace SignalRChat
{
    public partial class Startup
    {
     
        public void ConfigureSignalR(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
