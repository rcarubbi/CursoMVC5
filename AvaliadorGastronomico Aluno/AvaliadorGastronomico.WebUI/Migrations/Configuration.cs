namespace AvaliadorGastronomico.WebUI.Migrations
{
    using Domain;
    using Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<AvaliadorGastronomico.WebUI.Infrastructure.AvaliadorGastronomicoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AvaliadorGastronomico.WebUI.Infrastructure.AvaliadorGastronomicoDbContext context)
        {
          
            InitializeMembership(context);

            SeedRestaurantes(context);
        }

        private void InitializeMembership(AvaliadorGastronomicoDbContext context)
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Usuarios", "Id", "Login", true);

            var roles = (SimpleRoleProvider)System.Web.Security.Roles.Provider;
            var membership = (SimpleMembershipProvider)System.Web.Security.Membership.Provider;

            if (!roles.RoleExists("Admin"))
                roles.CreateRole("Admin");

            if (!roles.RoleExists("User"))
                roles.CreateRole("User");

            if (membership.GetUser("admin", false) == null)
            {
                WebSecurity.CreateUserAndAccount("admin", "admin");
            }
            if (!roles.IsUserInRole("admin", "Admin"))
                roles.AddUsersToRoles(new string[] { "admin" }, new string[] { "Admin" });
        }

        private void SeedRestaurantes(AvaliadorGastronomicoDbContext context)
        {
            var restaurante1 = new Restaurante
            {
                Nome = "Sushi Yassu - Liberdade 2",
                CaminhoImagem = "~/Content/images/Restaurante1.jpg",
                Endereco = new Endereco
                {
                    Cidade = "São Paulo",
                    Logradouro = "Rua Américo de Campos, 46",
                    UF = "SP",
                    Pais = "Brasil"
                },
                NomeChef = "Não Informado"
            };

            restaurante1.Criticas = new List<Critica> {
                new Critica {
                     Corpo = "Muito bom!",
                     Nota = 8,
                     DataCriacao = DateTime.Now,
                     DataRefeicao  = DateTime.Now.AddDays(-5).Date,
                },
                       new Critica {
                     Corpo = "Ótimo!",
                     Nota = 9,
                     DataCriacao = DateTime.Now,
                     DataRefeicao  = DateTime.Now.AddDays(-5).Date,
                },
            };

            var restaurante2 = new Restaurante
            {
                Nome = "Sushi Yassu - Liberdade",
                CaminhoImagem = "~/Content/images/Restaurante1.jpg",
                Endereco = new Endereco
                {
                    Cidade = "São Paulo",
                    Logradouro = "Rua Tomás Gonzaga, 98",
                    UF = "SP",
                    Pais = "Brasil"
                },
                NomeChef = "Não Informado"
            };

            restaurante2.Criticas = new List<Critica>
            {
                  new Critica {
                     Corpo = "Regular...",
                     Nota = 5,
                     DataCriacao = DateTime.Now,
                     DataRefeicao  = DateTime.Now.AddDays(-5).Date,
                }
            };

            context.Restaurantes.AddOrUpdate(r => r.Nome, restaurante1,
                restaurante2
             , new Restaurante
             {
                 Nome = "Shintori",
                 CaminhoImagem = "~/Content/images/Restaurante1.jpg",
                 Endereco = new Endereco
                 {
                     Cidade = "São Paulo",
                     Logradouro = "Alameda Campinas, 600",
                     UF = "SP",
                     Pais = "Brasil"
                 },
                 NomeChef = "Não Informado"
             },
             new Restaurante
             {
                 Nome = "SassáSushi - Itaim",
                 CaminhoImagem = "~/Content/images/Restaurante1.jpg",
                 Endereco = new Endereco
                 {
                     Cidade = "Rio de Janeiro",
                     Logradouro = "Avenida Horácio Lafer, 640",
                     UF = "RJ",
                     Pais = "Brasil"
                 },
                 NomeChef = "Não Informado"
             },
             new Restaurante
             {
                 Nome = "Momotaro",
                 CaminhoImagem = "~/Content/images/Restaurante1.jpg",
                 Endereco = new Endereco
                 {
                     Cidade = "Rio de Janeiro",
                     Logradouro = "Rua Diogo Jácome, 591",
                     UF = "RJ",
                     Pais = "Brasil"
                 },
                 NomeChef = "Não Informado"
             },
             new Restaurante
             {
                 Nome = "Aya Japanese Cuisine",
                 CaminhoImagem = "~/Content/images/Restaurante1.jpg",
                 Endereco = new Endereco
                 {
                     Cidade = "São Paulo",
                     Logradouro = "Avenida Pedroso de Morais, 141",
                     UF = "SP",
                     Pais = "Brasil"
                 },
                 NomeChef = "Não Informado"
             });
        }

    }
}
