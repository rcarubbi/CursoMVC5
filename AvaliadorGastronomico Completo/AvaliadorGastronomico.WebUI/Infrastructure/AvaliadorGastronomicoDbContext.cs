using AvaliadorGastronomico.Domain;
using System.Data.Entity;
using System.Linq;

namespace AvaliadorGastronomico.WebUI.Infrastructure
{
    public class AvaliadorGastronomicoDbContext : DbContext, IDbContext
    {
        public AvaliadorGastronomicoDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Critica> Criticas { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        IQueryable<Restaurante> IDbContext.Restaurantes
        {
            get { return Restaurantes; }
        }

        IQueryable<Critica> IDbContext.Criticas
        {
            get { return Criticas; }
        }

        IQueryable<Usuario> IDbContext.Usuarios
        {
            get { return Usuarios; }
        }

        public void AddUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        public void DisableProxy()
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public void RemoveUsuario(Usuario usuario)
        {
            Usuarios.Remove(usuario);
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}