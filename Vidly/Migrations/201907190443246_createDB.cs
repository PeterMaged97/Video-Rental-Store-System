namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        isSubscribed = c.Boolean(nullable: false),
                        MembershipTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeID, cascadeDelete: true)
                .Index(t => t.MembershipTypeID);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        discountRate = c.Byte(nullable: false),
                        durationInMonths = c.Byte(nullable: false),
                        signupFee = c.Short(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeID" });
            DropTable("dbo.Movies");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}
