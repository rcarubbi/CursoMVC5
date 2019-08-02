using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatanaIntroIIS
{
    using System.IO;
    using System.Web.Http;
    using AppFunc = Func<IDictionary<string, object>, Task>;
   
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.Use(async (context, next) => {
                Console.WriteLine("Request: {0} ", context.Request.Path);

                await next();

                Console.WriteLine("Response: {0}", context.Response.StatusCode);
            });

            ConfigureWebApi(app);

            app.UseHelloWorld();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            app.UseWebApi(configuration);
        }
    }


    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }

    public class HelloWorldComponent
    {
 
 
        public HelloWorldComponent(AppFunc next)
        {
           
        }

        // conforme a assinatura da func
        public Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!");
            }

            // deve retornar uma task ou lançar uma exceção segundo a especificação.
        }
    }
    
}
