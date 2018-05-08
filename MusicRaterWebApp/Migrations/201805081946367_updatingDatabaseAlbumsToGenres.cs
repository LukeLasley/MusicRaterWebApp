namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingDatabaseAlbumsToGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AlbumGenres (albumId,genreId) VALUES (1,1)");
            Sql("INSERT INTO AlbumGenres (albumId,genreId) VALUES (2,3)");
            Sql("INSERT INTO AlbumGenres (albumId,genreId) VALUES (3,3)");
            Sql("INSERT INTO AlbumGenres (albumId,genreId) VALUES (4,3)");
            Sql("INSERT INTO AlbumGenres (albumId,genreId) VALUES (5,1)");
        }
        
        public override void Down()
        {
        }
    }
}
