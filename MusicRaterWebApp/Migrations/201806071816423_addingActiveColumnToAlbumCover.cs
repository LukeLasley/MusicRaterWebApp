namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingActiveColumnToAlbumCover : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlbumCovers", "active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AlbumCovers", "active");
        }
    }
}
