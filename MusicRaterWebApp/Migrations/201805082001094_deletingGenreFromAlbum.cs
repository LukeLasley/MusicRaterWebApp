namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingGenreFromAlbum : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Albums", "genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "genre", c => c.String());
        }
    }
}
