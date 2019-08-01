using AvaliadorGastronomico.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMatrix.WebData;

namespace AvaliadorGastronomico.WebUI.Api
{
    public class UsuarioController : ApiController
    {
        private readonly IDbContext _context;

        public UsuarioController(IDbContext context)
        {
            _context = context;
            _context.DisableProxy();
        }

        // GET api/<controller>
        public IEnumerable<Usuario> Get()
        {
            return _context.Usuarios;
        }

        // GET api/<controller>/5
        public Usuario Get(int id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return usuario;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.AddUsuario(usuario);
                _context.SaveChanges();

                WebSecurity.CreateAccount(usuario.Login, "teste123");
                var roles = (SimpleRoleProvider)System.Web.Security.Roles.Provider;
                roles.AddUsersToRoles(new string[] { usuario.Login }, new string[] { "User" });

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

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Usuario usuario)
        {
            if (ModelState.IsValid && id == usuario.Id)
            {
                var usuarioAnterior = _context.Usuarios.Single(x => x.Id == id);

                var roles = (SimpleRoleProvider)System.Web.Security.Roles.Provider;
                roles.RemoveUsersFromRoles(new string[] { usuarioAnterior.Login }, new string[] { "User" });

                var membership = (SimpleMembershipProvider)System.Web.Security.Membership.Provider;
                membership.DeleteAccount(usuarioAnterior.Login);

                usuarioAnterior.Login = usuario.Login;
                _context.SetModified(usuarioAnterior);
                try
                {
                    _context.SaveChanges();

                    WebSecurity.CreateAccount(usuario.Login, "teste123");
                    roles.AddUsersToRoles(new string[] { usuario.Login }, new string[] { "User" });
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

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var roles = (SimpleRoleProvider)System.Web.Security.Roles.Provider;
            roles.RemoveUsersFromRoles(new string[] { usuario.Login }, new string[] { "User" });

            var membership = (SimpleMembershipProvider)System.Web.Security.Membership.Provider;
            membership.DeleteAccount(usuario.Login);

            _context.RemoveUsuario(usuario);
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
    }
}