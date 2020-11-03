namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {

            Sql(@"INSERT INTO Genres (name) VALUES ('Action');
INSERT INTO Genres(name) VALUES('Comedy');
            INSERT INTO Genres(name) VALUES('Sci-Fi');
            INSERT INTO Genres(name) VALUES('Adventure');
            INSERT INTO Genres(name) VALUES('Drama'); ");

        }
        
        public override void Down()
        {
        }
    }
}
