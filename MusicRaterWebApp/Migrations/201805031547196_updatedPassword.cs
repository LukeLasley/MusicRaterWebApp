namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedPassword : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Passwords");
            DropColumn("dbo.Passwords", "userId");
            AddColumn("dbo.Passwords", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Passwords", "id");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Passwords", "userId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Passwords");
            DropColumn("dbo.Passwords", "id");
            AddPrimaryKey("dbo.Passwords", "userId");
        }
    }
}
