namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedGenreAlbumJunctionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumGenres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        albumId = c.Int(nullable: false),
                        genreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AlbumGenres");
        }
    }
}
