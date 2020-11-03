namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctBirthDateNamin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "birthdate", c => c.DateTime(storeType: "date"));
            DropColumn("dbo.Customers", "ReportDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ReportDate", c => c.DateTime(storeType: "date"));
            DropColumn("dbo.Customers", "birthdate");
        }
    }
}
