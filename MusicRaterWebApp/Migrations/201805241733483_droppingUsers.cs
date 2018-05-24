namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droppingUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAlbumRanks", "userId", "dbo.Users");
            DropIndex("dbo.UserAlbumRanks", new[] { "userId" });
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        userFirstName = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.UserAlbumRanks", "userId");
            AddForeignKey("dbo.UserAlbumRanks", "userId", "dbo.Users", "id", cascadeDelete: true);
        }
    }
}
