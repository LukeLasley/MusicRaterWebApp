namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingReviewsToHaveAlbum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserReviews", "album_albumId", c => c.Int());
            CreateIndex("dbo.UserReviews", "album_albumId");
            AddForeignKey("dbo.UserReviews", "album_albumId", "dbo.Albums", "albumId");
            DropColumn("dbo.UserReviews", "albumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserReviews", "albumId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserReviews", "album_albumId", "dbo.Albums");
            DropIndex("dbo.UserReviews", new[] { "album_albumId" });
            DropColumn("dbo.UserReviews", "album_albumId");
        }
    }
}
