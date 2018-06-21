namespace MusicRaterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialTrustedUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4c478fe7-91ee-481f-896f-03624801b308', N'trusteduser@musicrater.com', 0, N'APQ7TLp2359czfmOyaY46PkuNzBwag6kuTi9Vol4PmuFVKDEbBzm/wwCoeRuMpHiqw==', N'2af0eaab-6a77-46dc-8ab8-88f60f7fcc41', NULL, 0, 0, NULL, 1, 0, N'trusteduser')");
            Sql("INSERT INTO[dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES(N'4c478fe7-91ee-481f-896f-03624801b308', N'0a741944-f2ba-41ec-89d8-e6950fd21520')");
        }

    public override void Down()
        {
        }
    }
}
