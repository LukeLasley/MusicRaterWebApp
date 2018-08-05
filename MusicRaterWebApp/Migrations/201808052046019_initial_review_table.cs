namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_review_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserReviews",
                c => new
                    {
                        reviewId = c.Int(nullable: false, identity: true),
                        albumId = c.Int(nullable: false),
                        userId = c.String(),
                        dateUpdated = c.DateTime(nullable: false),
                        review = c.String(),
                    })
                .PrimaryKey(t => t.reviewId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserReviews");
        }
    }
}
