using AvaliadorGastronomico.Domain;
using System.Collections.Generic;
using System.Linq;

namespace AvaliadorGastronomico.WebUI.Tests
{
    public class MockContext : IDbContext
    {
        private List<Restaurante> _restaurantes = new List<Restaurante>();
        private List<Critica> _criticas = new List<Critica>();
        private List<Usuario> _usuarios = new List<Usuario>();

        public IQueryable<Restaurante> Restaurantes
        {
            get
            {
                return _restaurantes.AsQueryable();
            }
        }

        public IQueryable<Critica> Criticas
        {
            get
            {
                return _criticas.AsQueryable();
            }
        }

        public IQueryable<Usuario> Usuarios
        {
            get { return _usuarios.AsQueryable(); }
        }

        public void AddUsuario(Usuario usuario)
        {
            Usuarios.ToList().Add(usuario);
        }

        public void DisableProxy()
        {

        }

        public void RemoveUsuario(Usuario usuario)
        {
            Usuarios.ToList().Remove(usuario);
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void SetModified(object entity)
        {

        }
    }
}
