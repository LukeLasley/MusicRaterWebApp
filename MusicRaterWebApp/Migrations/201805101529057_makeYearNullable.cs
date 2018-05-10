namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeYearNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "year", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "year", c => c.Int(nullable: false));
        }
    }
}
