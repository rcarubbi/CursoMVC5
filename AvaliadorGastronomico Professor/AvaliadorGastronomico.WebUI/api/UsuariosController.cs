using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AvaliadorGastronomico.Domain;
using AvaliadorGastronomico.WebUI.Infrastructure;

namespace AvaliadorGastronomico.WebUI.api
{
    #region Slide 72
    public class UsuariosController : ApiController
    {
        private AvaliadorGastronomicoDbContext _context;

        public UsuariosController()
        {
            _context = new AvaliadorGastronomicoDbContext();
            // desabilita funcionalidades de change-tracking e lazyload
            _context.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Restaurantes
        public IEnumerable<Usuario> Get()
        {
            return _context.Usuarios;
        }

        // GET api/Restaurantes/5
        public Usuario Get(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return usuario;

        }

        // POST api/Restaurantes
        public HttpResponseMessage Post(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                // respeitando a especificação HTTP da W3C que diz que quando um post é enviado, 
                // o servidor deve retornar o status 201 (Created) junto com a chave location no cabeçalho 
                // apontando para a URL do novo recurso criado
                // http://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, usuario);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = usuario.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        // PUT api/Restaurantes/5
        public HttpResponseMessage Put(int id, Usuario usuario)
        {
            if (ModelState.IsValid && id == usuario.Id)
            {
                _context.SetModified(usuario);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, usuario);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Restaurantes/5
        public HttpResponseMessage Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _context.Usuarios.Remove(usuario);
            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }
    }
    #endregion
}
