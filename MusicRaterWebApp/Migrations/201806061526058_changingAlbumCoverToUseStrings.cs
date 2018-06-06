namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingAlbumCoverToUseStrings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlbumCovers", "albumCoverId", c => c.String());
            DropColumn("dbo.AlbumCovers", "albumImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlbumCovers", "albumImage", c => c.Binary());
            DropColumn("dbo.AlbumCovers", "albumCoverId");
        }
    }
}
