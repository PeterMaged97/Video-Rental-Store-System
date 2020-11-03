namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makebirthdatenullable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ReportDate", c => c.DateTime(storeType: "date"));
            DropColumn("dbo.Customers", "birthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "birthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "ReportDate");
        }
    }
}
