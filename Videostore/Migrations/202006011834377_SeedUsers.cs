namespace Videostore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"

           INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'11588b32-c1aa-4435-8748-bc0bd4b33d9f', N'admin1@gmail.com', 0, N'AFHDE7s19nGahjC0FQlY6eHKy/H5FhOhStGw+6KfmKSxG4dX7HrMk85ovZbcU4Bikw==', N'c0b93721-9041-423a-8c75-f77fffe0ce43', NULL, 0, 0, NULL, 1, 0, N'admin1@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'71b2d8d2-2da5-43a0-851d-54144d50172b', N'zoki_but@yahoo.com', 0, N'ALqpRNqRMtvwNxanJXsOM3VR48cp98gK+F7aOGrg48GMCbHSusVpuXHe+rJJpO8YXA==', N'fe14c5c7-4613-45df-8fa6-5a77c23460bc', NULL, 0, 0, NULL, 1, 0, N'zoki_but@yahoo.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aad3886e-1afc-45f7-8f55-85ac3065360d', N'adminZoki@gmail.com', 0, N'AE1ujCD/vUjU3rqbKUezHJFaJzhOS31+srrRoijTZZ82EaCwu7Tv2LGY3jdJfgul7A==', N'f8230d8a-567d-4bce-af2e-55ef01189315', NULL, 0, 0, NULL, 1, 0, N'adminZoki@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4f1fef40-f582-494c-81c7-798143a5702b', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'11588b32-c1aa-4435-8748-bc0bd4b33d9f', N'4f1fef40-f582-494c-81c7-798143a5702b')


");

        }
        
        public override void Down()
        {
        }
    }
}
