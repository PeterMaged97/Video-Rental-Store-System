namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctionToGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Movies", "GenreID", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreID");
            AddForeignKey("dbo.Movies", "GenreID", "dbo.Genres", "id", cascadeDelete: true);
            DropColumn("dbo.Movies", "genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "genre", c => c.String());
            DropForeignKey("dbo.Movies", "GenreID", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreID" });
            DropColumn("dbo.Movies", "GenreID");
            DropTable("dbo.Genres");
        }
    }
}
