namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingAlbumAndGenreToCreateJunctionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreAlbums",
                c => new
                    {
                        Genre_id = c.Int(nullable: false),
                        Album_albumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_id, t.Album_albumId })
                .ForeignKey("dbo.Genres", t => t.Genre_id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_albumId, cascadeDelete: true)
                .Index(t => t.Genre_id)
                .Index(t => t.Album_albumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenreAlbums", "Album_albumId", "dbo.Albums");
            DropForeignKey("dbo.GenreAlbums", "Genre_id", "dbo.Genres");
            DropIndex("dbo.GenreAlbums", new[] { "Album_albumId" });
            DropIndex("dbo.GenreAlbums", new[] { "Genre_id" });
            DropTable("dbo.GenreAlbums");
        }
    }
}
