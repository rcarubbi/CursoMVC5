using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace AvaliadorGastronomico.WebUI.ServiceClient
{
    public class TempoServiceClient
    {
        public string RecuperarPrevisao()
        {
            Thread.Sleep(2000);
            return "18°C";
        }

        public async Task<string> RecuperarPrevisaoAsync()
        {
            return await Task.Factory.StartNew(new Func<string>(RecuperarPrevisao));
        }

        public IAsyncResult BeginRecuperarPrevisao(AsyncCallback callback, object state)
        {
            Func<string> worker = new Func<string>(RecuperarPrevisao);
            return worker.BeginInvoke(callback, state);
        }

        public string EndRecuperarPrevisao(IAsyncResult ar)
        {
            Func<string> worker = (Func<string>)((AsyncResult)ar).AsyncDelegate;
            return worker.EndInvoke(ar);
        }
    }
}