namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingDatabaseWithGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (genre) VALUES ('Metal')");
            Sql("INSERT INTO Genres (genre) VALUES ('Pop')");
            Sql("INSERT INTO Genres (genre) VALUES ('Rock')");
            Sql("INSERT INTO Genres (genre) VALUES ('Classical')");
            Sql("INSERT INTO Genres (genre) VALUES ('Country')");
            Sql("INSERT INTO Genres (genre) VALUES ('Rap')");
        }
        
        public override void Down()
        {
        }
    }
}
