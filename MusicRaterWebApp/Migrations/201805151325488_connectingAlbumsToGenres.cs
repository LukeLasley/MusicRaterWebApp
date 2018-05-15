namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class connectingAlbumsToGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreAlbums (Album_albumId,Genre_id) VALUES (2,3)");
            Sql("INSERT INTO GenreAlbums (Album_albumId,Genre_id) VALUES (3,3)");
            Sql("INSERT INTO GenreAlbums (Album_albumId,Genre_id) VALUES (4,3)");
            Sql("INSERT INTO GenreAlbums (Album_albumId,Genre_id) VALUES (5,1)");
        }
        
        public override void Down()
        {
        }
    }
}
