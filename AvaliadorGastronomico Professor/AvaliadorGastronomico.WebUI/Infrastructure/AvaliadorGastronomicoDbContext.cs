using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AvaliadorGastronomico.Domain;

namespace AvaliadorGastronomico.WebUI.Infrastructure
{
    #region Slide 19
    /* public class AvaliadorGastronomicoDbContext : DbContext
    {
        public AvaliadorGastronomicoDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Critica> Criticas { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
    }*/
    #endregion

    #region Slide 66
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

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
    #endregion
}