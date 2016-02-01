using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace AvaliadorGastronomico.WebUI.ServiceClients
{
    public class TempoServiceClient
    {
        public string RecuperarPrevisao()
        {
            Thread.Sleep(2000);
            return "18°C";
        }

        public IAsyncResult BeginRecuperarPrevisao(AsyncCallback callback, object state)
        {
            Func<String> worker = new Func<String>(RecuperarPrevisao);
            return worker.BeginInvoke(callback, state);
        }

        public string EndRecuperarPrevisao(IAsyncResult ar)
        {
            Func<string> worker = (Func<string>)((AsyncResult)ar).AsyncDelegate;
            return worker.EndInvoke(ar);
        }

        public Task<string> RecuperarPrevisaoAsync()
        {
            return Task.Factory.StartNew(new Func<String>(RecuperarPrevisao));
        }

       
      
    }
}