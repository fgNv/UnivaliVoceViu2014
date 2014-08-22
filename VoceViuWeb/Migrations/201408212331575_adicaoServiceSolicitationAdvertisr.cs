namespace VoceViuWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicaoServiceSolicitationAdvertisr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VV_ServiceSolicitations", "Advertiser_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.VV_ServiceSolicitations", "Advertiser_Id");
            AddForeignKey("dbo.VV_ServiceSolicitations", "Advertiser_Id", "dbo.VV_Advertisers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VV_ServiceSolicitations", "Advertiser_Id", "dbo.VV_Advertisers");
            DropIndex("dbo.VV_ServiceSolicitations", new[] { "Advertiser_Id" });
            DropColumn("dbo.VV_ServiceSolicitations", "Advertiser_Id");
        }
    }
}
