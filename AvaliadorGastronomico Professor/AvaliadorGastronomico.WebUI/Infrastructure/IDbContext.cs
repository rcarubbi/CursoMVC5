using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliadorGastronomico.Domain;

namespace AvaliadorGastronomico.WebUI.Infrastructure
{
    #region Slide 66
    public interface IDbContext 
    {
        IQueryable<Restaurante> Restaurantes { get; }
        IQueryable<Critica> Criticas { get; }
        IQueryable<Usuario> Usuarios { get; }

        int SaveChanges();
        void SetModified(object entity);
    }
    #endregion

}
