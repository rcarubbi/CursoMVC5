using AvaliadorGastronomico.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AvaliadorGastronomico.WebUI.Infrastructure
{
    public class AvaliadorGastronomicoDbContext : DbContext
    {
        public AvaliadorGastronomicoDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Critica> Criticas { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
    }
}