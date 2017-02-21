using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRChat.Startup))]

namespace SignalRChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureSignalR(app);
        }
    }
}
