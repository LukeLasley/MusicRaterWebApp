namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialSpotify : DbMigration
    {
        public override void Up()
        {
            Sql("Update dbo.Albums SET spotifyUri = 'spotify:album:56mXsvBsKgRCXgmtzOAC22' WHERE albumId = 1");
            Sql("Update dbo.Albums SET spotifyUri = 'spotify:album:7vtq4mlZSC1HC4a6UdcVug' WHERE albumId = 2");
            Sql("Update dbo.Albums SET spotifyUri = 'spotify:album:5M8xQaQZuW2LZGVXZ3mlKN' WHERE albumId = 3");
            Sql("Update dbo.Albums SET spotifyUri = 'spotify:album:3HA1Ru1gEAgaxTywkJmBOL' WHERE albumId = 4");
        }
        
        public override void Down()
        {
        }
    }
}
