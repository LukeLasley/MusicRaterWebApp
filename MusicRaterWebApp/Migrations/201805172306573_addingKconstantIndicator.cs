namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingKconstantIndicator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAlbumRanks", "timesSeen", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAlbumRanks", "timesSeen");
        }
    }
}
