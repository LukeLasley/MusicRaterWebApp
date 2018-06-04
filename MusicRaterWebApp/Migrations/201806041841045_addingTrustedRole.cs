namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTrustedRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'0a741944-f2ba-41ec-89d8-e6950fd21520', N'Trusted')");
        }
        
        public override void Down()
        {
        }
    }
}
