namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertingAlbumsIntoDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Albums (albumName,bandName,year,genre) VALUES ('Colors','Between the Buried and Me', 2007, 'Metal')");
            Sql("INSERT INTO Albums (albumName,bandName,year,genre) VALUES ('Plastic Surgery Disasters','Dead Kennedys', 1982, 'Punk')");
            Sql("INSERT INTO Albums (albumName,bandName,year,genre) VALUES ('My Woman','Angel Olsen', 2016, 'Indie')");
            Sql("INSERT INTO Albums (albumName,bandName,year,genre) VALUES ('Congratulations','MGMT', 2010, 'Alternative')");
        }
        
        public override void Down()
        {
        }
    }
}
