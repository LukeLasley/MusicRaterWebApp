namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingSpotifyPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "spotifyURi", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "spotifyURi");
        }
    }
}
