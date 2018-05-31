namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingAdminAccount : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b60499d4-8ca0-47c8-98ac-8489aaed5b90', N'admin@musicrater.com', 0, N'AJegFXLadfbKXdgLusMsrb+/EMIGVYlpmkJJ56eSNGPrDkKm8fXCJrxkjLAZexVqsQ==', N'6300164a-6e60-48ef-a381-df49bd26adde', NULL, 0, 0, NULL, 1, 0, N'admin')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'abde2770-8cbd-4e53-b9aa-1fadd42b4346', N'Administrator')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b60499d4-8ca0-47c8-98ac-8489aaed5b90', N'abde2770-8cbd-4e53-b9aa-1fadd42b4346')");
        }
        
        public override void Down()
        {
        }
    }
}
