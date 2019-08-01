using System.Linq;

namespace AvaliadorGastronomico.Domain
{
    public interface IDbContext
    {
        IQueryable<Restaurante> Restaurantes { get; }

        IQueryable<Critica> Criticas { get; }

        IQueryable<Usuario> Usuarios { get; }

        int SaveChanges();
        void SetModified(object entity);
        void DisableProxy();
        void AddUsuario(Usuario usuario);
        void RemoveUsuario(Usuario usuario);
    }
}
