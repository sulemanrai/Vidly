namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
             INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7ef06281-0470-480d-896d-76b3d34214c1', N'admin@vidly.com', 0, N'AH22iNFR+RRqs4YeIco7LBkaN5PCEXVLwZnWC32Om0Ykgq14vsY7ZmdFaJdDqkS5kg==', N'6ffe6034-ab33-4670-bbd6-ee9dcafcf648', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
             INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bed21294-a68b-47ae-8100-fa7452bc9ec8', N'guest@vidly.com', 0, N'AHy9gN9/VRv+0iwvS5bhUTJbSwSn2gZle3A3xHTkPNOatT0IGzlbBE0DeJN8hP8mQg==', N'e3f2980e-3251-4b1f-8f7d-16556f950e28', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')    
             INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0bb4b33d-1de7-4ab5-b2fe-0c28fcb5f00b', N'CanManageMovies')
             INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7ef06281-0470-480d-896d-76b3d34214c1', N'0bb4b33d-1de7-4ab5-b2fe-0c28fcb5f00b')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
