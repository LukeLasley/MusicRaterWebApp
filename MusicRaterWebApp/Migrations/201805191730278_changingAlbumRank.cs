namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingAlbumRank : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAlbumRanks", "album_albumId", "dbo.Albums");
            DropForeignKey("dbo.UserAlbumRanks", "user_id", "dbo.Users");
            DropIndex("dbo.UserAlbumRanks", new[] { "album_albumId" });
            DropIndex("dbo.UserAlbumRanks", new[] { "user_id" });
            RenameColumn(table: "dbo.UserAlbumRanks", name: "user_id", newName: "userId");
            AddColumn("dbo.UserAlbumRanks", "albumId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserAlbumRanks", "userId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserAlbumRanks", "userId");
            AddForeignKey("dbo.UserAlbumRanks", "userId", "dbo.Users", "id", cascadeDelete: true);
            DropColumn("dbo.UserAlbumRanks", "album_albumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAlbumRanks", "album_albumId", c => c.Int());
            DropForeignKey("dbo.UserAlbumRanks", "userId", "dbo.Users");
            DropIndex("dbo.UserAlbumRanks", new[] { "userId" });
            AlterColumn("dbo.UserAlbumRanks", "userId", c => c.Int());
            DropColumn("dbo.UserAlbumRanks", "albumId");
            RenameColumn(table: "dbo.UserAlbumRanks", name: "userId", newName: "user_id");
            CreateIndex("dbo.UserAlbumRanks", "user_id");
            CreateIndex("dbo.UserAlbumRanks", "album_albumId");
            AddForeignKey("dbo.UserAlbumRanks", "user_id", "dbo.Users", "id");
            AddForeignKey("dbo.UserAlbumRanks", "album_albumId", "dbo.Albums", "albumId");
        }
    }
}
