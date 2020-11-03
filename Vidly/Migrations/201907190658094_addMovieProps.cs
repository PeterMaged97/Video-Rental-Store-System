namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovieProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.Movies", "stock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "genre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "genre");
            DropColumn("dbo.Movies", "stock");
            DropColumn("dbo.Movies", "releaseDate");
        }
    }
}
