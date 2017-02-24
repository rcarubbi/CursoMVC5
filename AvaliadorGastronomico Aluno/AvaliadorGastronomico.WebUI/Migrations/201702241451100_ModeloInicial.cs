namespace AvaliadorGastronomico.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Criticas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Corpo = c.String(nullable: false),
                        Nota = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataRefeicao = c.DateTime(nullable: false),
                        Restaurante_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurantes", t => t.Restaurante_Id, cascadeDelete: true)
                .Index(t => t.Restaurante_Id);
            
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco_Logradouro = c.String(),
                        Endereco_Cidade = c.String(),
                        Endereco_UF = c.String(),
                        Endereco_Pais = c.String(),
                        CaminhoImagem = c.String(),
                        NomeChef = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Criticas", "Restaurante_Id", "dbo.Restaurantes");
            DropIndex("dbo.Criticas", new[] { "Restaurante_Id" });
            DropTable("dbo.Restaurantes");
            DropTable("dbo.Criticas");
        }
    }
}
