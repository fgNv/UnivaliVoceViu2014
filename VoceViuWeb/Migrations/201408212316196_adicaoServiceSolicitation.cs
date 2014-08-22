namespace VoceViuWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicaoServiceSolicitation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VV_Advertisements",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        File = c.Binary(),
                        FileName = c.String(),
                        ContractModel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VV_ContractModel", t => t.ContractModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.VV_ServiceSolicitations", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.ContractModel_Id);
            
            CreateTable(
                "dbo.VV_ContractModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Terms = c.String(),
                        Summary = c.String(),
                        File = c.Binary(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VV_Advertisements_Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        DenialDate = c.DateTime(nullable: false),
                        File = c.Binary(),
                        FileName = c.String(),
                        Advertisement_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VV_Advertisements", t => t.Advertisement_Id, cascadeDelete: true)
                .Index(t => t.Advertisement_Id);
            
            CreateTable(
                "dbo.VV_ServiceSolicitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeriodoInicial = c.DateTime(nullable: false),
                        PeriodoFim = c.DateTime(nullable: false),
                        ValorMensal = c.Double(nullable: false),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VV_Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VV_ServiceSolicitations", "Location_Id", "dbo.VV_Locations");
            DropForeignKey("dbo.VV_Advertisements", "Id", "dbo.VV_ServiceSolicitations");
            DropForeignKey("dbo.VV_Advertisements_Contents", "Advertisement_Id", "dbo.VV_Advertisements");
            DropForeignKey("dbo.VV_Advertisements", "ContractModel_Id", "dbo.VV_ContractModel");
            DropIndex("dbo.VV_ServiceSolicitations", new[] { "Location_Id" });
            DropIndex("dbo.VV_Advertisements_Contents", new[] { "Advertisement_Id" });
            DropIndex("dbo.VV_Advertisements", new[] { "ContractModel_Id" });
            DropIndex("dbo.VV_Advertisements", new[] { "Id" });
            DropTable("dbo.VV_ServiceSolicitations");
            DropTable("dbo.VV_Advertisements_Contents");
            DropTable("dbo.VV_ContractModel");
            DropTable("dbo.VV_Advertisements");
        }
    }
}
