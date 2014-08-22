namespace VoceViuWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renomeDeColuna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VV_ServiceSolicitations", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.VV_ServiceSolicitations", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.VV_ServiceSolicitations", "MonthlyValue", c => c.Double(nullable: false));
            DropColumn("dbo.VV_ServiceSolicitations", "PeriodoInicial");
            DropColumn("dbo.VV_ServiceSolicitations", "PeriodoFim");
            DropColumn("dbo.VV_ServiceSolicitations", "ValorMensal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VV_ServiceSolicitations", "ValorMensal", c => c.Double(nullable: false));
            AddColumn("dbo.VV_ServiceSolicitations", "PeriodoFim", c => c.DateTime(nullable: false));
            AddColumn("dbo.VV_ServiceSolicitations", "PeriodoInicial", c => c.DateTime(nullable: false));
            DropColumn("dbo.VV_ServiceSolicitations", "MonthlyValue");
            DropColumn("dbo.VV_ServiceSolicitations", "EndDate");
            DropColumn("dbo.VV_ServiceSolicitations", "StartDate");
        }
    }
}
