namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialalbumcovers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[AlbumCovers] ([albumId], [albumCoverId], [active]) VALUES(4, N'0201ad7d-ff72-4d71-b4b0-bb765798be91MGMT_Congratulations.jpg', 1)");
            Sql("INSERT INTO[dbo].[AlbumCovers] ([albumId], [albumCoverId], [active]) VALUES(3, N'fb85c824-424f-4ee4-85f5-e6ba776c4061b536a49e.jpg', 1)");
            Sql("INSERT INTO[dbo].[AlbumCovers] ([albumId], [albumCoverId], [active]) VALUES(2, N'af7a77a2-be99-443b-87d3-10897abefa8aDead_Kennedys_-_Plastic_Surgery_Disasters_cover.jpg', 1)");
            Sql("INSERT INTO[dbo].[AlbumCovers] ([albumId], [albumCoverId], [active]) VALUES(1, N'a2c12eb6-a0aa-4d33-9691-4ddde592c97a2f30be52c5cb64c90b9de81e92c85b023b7b3fc0.jpg', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
