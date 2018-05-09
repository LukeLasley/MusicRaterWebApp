namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class albumNowHasRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "albumName", c => c.String(nullable: false));
            AlterColumn("dbo.Albums", "bandName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "bandName", c => c.String());
            AlterColumn("dbo.Albums", "albumName", c => c.String());
        }
    }
}
