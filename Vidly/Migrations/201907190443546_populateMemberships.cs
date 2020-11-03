namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMemberships : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (discountRate, durationInMonths, signupFee, name) VALUES (0, 0, 0, 'Pay As You Go')");
            Sql("INSERT INTO MembershipTypes (discountRate, durationInMonths, signupFee, name) VALUES (10, 1, 30, 'Monthly')");
            Sql("INSERT INTO MembershipTypes (discountRate, durationInMonths, signupFee, name) VALUES (15, 3, 90, 'Quarterly')");
            Sql("INSERT INTO MembershipTypes (discountRate, durationInMonths, signupFee, name) VALUES (20, 12, 300, 'Annual')");
        }
        
        public override void Down()
        {
        }
    }
}
