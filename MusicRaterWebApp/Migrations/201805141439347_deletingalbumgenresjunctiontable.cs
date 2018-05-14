namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingalbumgenresjunctiontable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AlbumGenres");
        }
        
        public override void Down()
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
    }
}
