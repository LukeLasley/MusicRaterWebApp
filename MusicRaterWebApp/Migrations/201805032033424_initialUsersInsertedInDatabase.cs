namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialUsersInsertedInDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Users (userName, userFirstName) VALUES ('USERA', 'A')");
            Sql("INSERT INTO Users (userName, userFirstName) VALUES ('USERB', 'B')");
            Sql("INSERT INTO Users (userName, userFirstName) VALUES ('USERC', 'C')");
            Sql("INSERT INTO Users (userName, userFirstName) VALUES ('USERD', 'D')");
        }
        
        public override void Down()
        {
        }
    }
}
