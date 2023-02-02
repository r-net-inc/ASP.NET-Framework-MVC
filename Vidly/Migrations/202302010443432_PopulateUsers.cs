namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'14ffe302-1173-43e4-bd77-e0afada65415', N'rana.sri@r-net.tech', 0, N'AGhym0X5OMPKBAVD2e8LkGwm2rEobic6EPS/t/fRROF5Kys3YjFHf4XNA2hjL3d5Tw==', N'f1794bb1-8249-4ecf-b07f-a80f3310b945', NULL, 0, 0, NULL, 1, 0, N'rana.sri@r-net.tech')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'70a06352-f76f-411b-80b0-5b0745a96557', N'testuser@testuser.net', 0, N'ACDum6gzU016gNbTAdaTfTaa+6sOBMT7eGonpvcxejPJADEHjMSiCHsq0TOXTVcTAA==', N'44efab34-c006-4aec-90ec-f5b3b1e46f75', NULL, 0, 0, NULL, 1, 0, N'testuser@testuser.net')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9fecf92a-3aed-446f-ab9e-c004f40b779c', N'CanManageCustomers')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e87c12a3-0b1e-4879-85ef-99aee58ceb00', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'018d3a23-0752-4616-aa44-82e092e0b4a9', N'CanManageRentals')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'14ffe302-1173-43e4-bd77-e0afada65415', N'018d3a23-0752-4616-aa44-82e092e0b4a9')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'14ffe302-1173-43e4-bd77-e0afada65415', N'9fecf92a-3aed-446f-ab9e-c004f40b779c')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'14ffe302-1173-43e4-bd77-e0afada65415', N'e87c12a3-0b1e-4879-85ef-99aee58ceb00')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
