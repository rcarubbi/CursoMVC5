using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace AvaliadorGastronomico.WebUI.ServiceClient
{
    public class NoticiaServiceClient
    {
        public string RecuperarManchete()
        {
            Thread.Sleep(2000);
            return "Extra!! Extra!!";
        }

        public async Task<string> RecuperarMancheteAsync()
        {
            return await Task.Factory.StartNew(new Func<string>(RecuperarManchete));
        }

        public IAsyncResult BeginRecuperarManchetes(AsyncCallback callback, object state)
        {
            Func<string> worker = new Func<string>(RecuperarManchete);
            return worker.BeginInvoke(callback, state);
        }

        public string EndRecuperarManchetes(IAsyncResult ar)
        {
            Func<string> worker = (Func<string>)((AsyncResult)ar).AsyncDelegate;
            return worker.EndInvoke(ar);
        }
    }
}