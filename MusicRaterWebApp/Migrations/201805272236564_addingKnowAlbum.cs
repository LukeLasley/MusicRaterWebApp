namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingKnowAlbum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAlbumRanks", "knowAlbum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAlbumRanks", "knowAlbum");
        }
    }
}
