using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace AvaliadorGastronomico.WebUI.ServiceClients
{
    // slide 77
    public class NoticiaServiceClient
    {

        public string RecuperarManchete()
        {
            Thread.Sleep(2000);
            return "Extra!! Extra!!";
        }

        public IAsyncResult BeginRecuperarManchetes(AsyncCallback callback, object state)
        {
            Func<String> worker = new Func<String>(RecuperarManchete);
            return worker.BeginInvoke(callback, state);
        }

        public string EndRecuperarManchetes(IAsyncResult ar)
        {
            Func<string> worker = (Func<string>)((AsyncResult)ar).AsyncDelegate;
            return worker.EndInvoke(ar);
        }

        public async Task<string> RecuperarMancheteAsync()
        {
            return await Task.Factory.StartNew(new Func<String>(RecuperarManchete));
        }

      
    }
}