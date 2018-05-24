namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingUserIdInAlbumRank : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAlbumRanks", "userId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAlbumRanks", "userId", c => c.Int(nullable: false));
        }
    }
}
