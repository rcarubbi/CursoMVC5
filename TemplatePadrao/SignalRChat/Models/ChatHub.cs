using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRChat.Models
{
    public class ChatHub : Hub
    {
        public void EnviarMensagem(string apelido, string mensagem)
        {
            Clients.All.TransmitirMensagem(apelido, mensagem);
        }
    }
}