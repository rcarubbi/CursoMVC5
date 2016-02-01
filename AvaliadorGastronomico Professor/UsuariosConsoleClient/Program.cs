using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UsuariosConsoleClient
{
    // Slide 73
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/xml"));

            var result = client.GetAsync(new Uri("http://localhost:51300/api/usuarios")).Result;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var doc = XDocument.Load(result.Content.ReadAsStreamAsync().Result);
                var ns = (XNamespace)"http://schemas.datacontract.org/2004/07/AvaliadorGastronomico.Domain";

                foreach(var login in doc.Descendants(ns + "Login"))
                {
                    Console.WriteLine(login.Value);
                }
                Console.ReadLine();
            }
        }
    }
}
