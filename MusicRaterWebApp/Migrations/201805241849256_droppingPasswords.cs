namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droppingPasswords : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Passwords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        password = c.String(),
                        salt = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
