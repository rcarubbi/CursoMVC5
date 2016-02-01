namespace AvaliadorGastronomico.WebUI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AvaliadorGastronomico.Domain;
    using AvaliadorGastronomico.WebUI.Infrastructure;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<AvaliadorGastronomico.WebUI.Infrastructure.AvaliadorGastronomicoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AvaliadorGastronomicoDbContext context)
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

            SeedRestaurantes(context);
        }

        private void SeedRestaurantes(AvaliadorGastronomicoDbContext context)
        {
            context.Restaurantes.AddOrUpdate(r => r.Nome, new Restaurante
            {
                Nome = "Sushi Yassu - Liberdade 2",
                CaminhoImagem = new UrlHelper(HttpContext.Current.Request.RequestContext).Content("~/Content/images/Restaurante1.jpg"),
                Endereco = new Endereco
                {
                    Cidade = "S�o Paulo",
                    Logradouro = "Rua Am�rico de Campos, 46",
                    UF = "SP",
                    Pais = "Brasil"
                },
                NomeChef = "N�o Informado"
            },
             new Restaurante
             {
                 Nome = "Sushi Yassu - Liberdade",
                 CaminhoImagem = new UrlHelper(HttpContext.Current.Request.RequestContext).Content("~/Content/images/Restaurante1.jpg"),
                 Endereco = new Endereco
                 {
                     Cidade = "S�o Paulo",
                     Logradouro = "Rua Tom�s Gonzaga, 98",
                     UF = "SP",
                     Pais = "Brasil"
                 },
                 NomeChef = "N�o Informado"
             }
             , new Restaurante
             {
                 Nome = "Shintori",
                 CaminhoImagem = new UrlHelper(HttpContext.Current.Request.RequestContext).Content("~/Content/images/Restaurante1.jpg"),
                 Endereco = new Endereco
                 {
                     Cidade = "S�o Paulo",
                     Logradouro = "Alameda Campinas, 600",
                     UF = "SP",
                     Pais = "Brasil"
                 },
                 NomeChef = "N�o Informado"
             },
             new Restaurante
             {
                 Nome = "Sass�Sushi - Itaim",
                 CaminhoImagem = new UrlHelper(HttpContext.Current.Request.RequestContext).Content("~/Content/images/Restaurante1.jpg"),
                 Endereco = new Endereco
                 {
                     Cidade = "S�o Paulo",
                     Logradouro = "Avenida Hor�cio Lafer, 640",
                     UF = "SP",
                     Pais = "Brasil"
                 },
                 NomeChef = "N�o Informado"
             },
             new Restaurante
             {
                 Nome = "Momotaro",
                 CaminhoImagem = new UrlHelper(HttpContext.Current.Request.RequestContext).Content("~/Content/images/Restaurante1.jpg"),
                 Endereco = new Endereco
                 {
                     Cidade = "S�o Paulo",
                     Logradouro = "Rua Diogo J�come, 591",
                     UF = "SP",
                     Pais = "Brasil"
                 },
                 NomeChef = "N�o Informado"
             },
             new Restaurante
             {
                 Nome = "Aya Japanese Cuisine",
                 CaminhoImagem = new UrlHelper(HttpContext.Current.Request.RequestContext).Content("~/Content/images/Restaurante1.jpg"),
                 Endereco = new Endereco
                 {
                     Cidade = "S�o Paulo",
                     Logradouro = "Avenida Pedroso de Morais, 141",
                     UF = "SP",
                     Pais = "Brasil"
                 },
                 NomeChef = "N�o Informado"
             });
        }
    }
}
