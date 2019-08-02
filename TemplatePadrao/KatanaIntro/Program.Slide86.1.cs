//using Microsoft.Owin.Hosting;
//using Owin;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace KatanaIntro
//{
//    using AppFunc = Func<System.Collections.Generic.IDictionary<string, object>, Task>;
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string uri = "Http://localhost:8080";
//            using (WebApp.Start<Startup>(uri))
//            {
//                Console.WriteLine("Started");
//                Console.ReadKey();
//                Console.WriteLine("Stopping");
//            }
//        }
//    }



//    public class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            app.Use<HelloWorldComponent>();
//        }
//    }

//    public class HelloWorldComponent
//    {


//        private AppFunc _next;
//        public HelloWorldComponent(AppFunc next)
//        {
//            _next = next;
//        }

//        // conforme a assinatura da func
//        public async Task Invoke(IDictionary<string, object> environment)
//        {

//            await _next(environment);
//            // deve retornar uma task ou lançar uma exceção segundo a especificação.
//        }
//    }

//}
