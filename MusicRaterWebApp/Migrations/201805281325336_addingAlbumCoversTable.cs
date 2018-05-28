namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingAlbumCoversTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumCovers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        albumId = c.Int(nullable: false),
                        albumImage = c.Binary(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AlbumCovers");
        }
    }
}
