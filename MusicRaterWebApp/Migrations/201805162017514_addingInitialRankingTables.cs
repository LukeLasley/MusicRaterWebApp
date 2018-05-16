namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingInitialRankingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAlbumRanks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rank = c.Int(nullable: false),
                        album_albumId = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Albums", t => t.album_albumId)
                .ForeignKey("dbo.Users", t => t.user_id)
                .Index(t => t.album_albumId)
                .Index(t => t.user_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAlbumRanks", "user_id", "dbo.Users");
            DropForeignKey("dbo.UserAlbumRanks", "album_albumId", "dbo.Albums");
            DropIndex("dbo.UserAlbumRanks", new[] { "user_id" });
            DropIndex("dbo.UserAlbumRanks", new[] { "album_albumId" });
            DropTable("dbo.UserAlbumRanks");
        }
    }
}
