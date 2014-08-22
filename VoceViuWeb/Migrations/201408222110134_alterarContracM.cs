namespace VoceViuWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterarContracM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VV_Advertisements", "ContractModel_Id", "dbo.VV_ContractModel");
            DropIndex("dbo.VV_Advertisements", new[] { "ContractModel_Id" });
            AddColumn("dbo.VV_ServiceSolicitations", "ContractModel_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.VV_ServiceSolicitations", "ContractModel_Id");
            AddForeignKey("dbo.VV_ServiceSolicitations", "ContractModel_Id", "dbo.VV_ContractModel", "Id", cascadeDelete: true);
            DropColumn("dbo.VV_Advertisements", "ContractModel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VV_Advertisements", "ContractModel_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.VV_ServiceSolicitations", "ContractModel_Id", "dbo.VV_ContractModel");
            DropIndex("dbo.VV_ServiceSolicitations", new[] { "ContractModel_Id" });
            DropColumn("dbo.VV_ServiceSolicitations", "ContractModel_Id");
            CreateIndex("dbo.VV_Advertisements", "ContractModel_Id");
            AddForeignKey("dbo.VV_Advertisements", "ContractModel_Id", "dbo.VV_ContractModel", "Id", cascadeDelete: true);
        }
    }
}
