namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        albumId = c.Int(nullable: false, identity: true),
                        albumName = c.String(),
                        bandName = c.String(),
                        year = c.Int(nullable: false),
                        genre = c.String(),
                    })
                .PrimaryKey(t => t.albumId);
            
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        password = c.String(),
                        salt = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Passwords");
            DropTable("dbo.Albums");
        }
    }
}
