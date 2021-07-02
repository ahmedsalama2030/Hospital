IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [Appointments] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [PatientName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [Note] nvarchar(max) NULL,
        [ClincName] nvarchar(max) NULL,
        CONSTRAINT [PK_Appointments] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [ClinicScheduls] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [ClinicName] nvarchar(max) NULL,
        [ClinicNameAr] nvarchar(max) NULL,
        [TimeFrom] nvarchar(max) NULL,
        [TimeTo] nvarchar(max) NULL,
        [IsSaturday] bit NOT NULL,
        [IsSunday] bit NOT NULL,
        [IsMonday] bit NOT NULL,
        [IsTuesday] bit NOT NULL,
        [IsWednesday] bit NOT NULL,
        [IsThursday] bit NOT NULL,
        [IsFriday] bit NOT NULL,
        CONSTRAINT [PK_ClinicScheduls] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [CommonQuestions] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [Title] nvarchar(max) NULL,
        [TitleAr] nvarchar(max) NULL,
        [description] nvarchar(max) NULL,
        [descriptionAr] nvarchar(max) NULL,
        CONSTRAINT [PK_CommonQuestions] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [ContactUs] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [Name] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Message] nvarchar(max) NULL,
        CONSTRAINT [PK_ContactUs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [GeneralSettings] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [SiteName] nvarchar(max) NULL,
        [SiteNameAr] nvarchar(max) NULL,
        [AdminSiteName] nvarchar(max) NULL,
        [AdminSiteNameAr] nvarchar(max) NULL,
        [SiteLogoPath] nvarchar(max) NULL,
        [ManegerHead] nvarchar(max) NULL,
        [ManegerHeadAr] nvarchar(max) NULL,
        [ManegerWord] nvarchar(max) NULL,
        [ManegerWordAr] nvarchar(max) NULL,
        [ManegerName] nvarchar(max) NULL,
        [ManegerNameAr] nvarchar(max) NULL,
        [ManegerPhotoPath] nvarchar(max) NULL,
        [VideoPath] nvarchar(max) NULL,
        [AboutUsDescription] nvarchar(max) NULL,
        [AboutUsDescriptionAr] nvarchar(max) NULL,
        [Value] nvarchar(max) NULL,
        [ValueAr] nvarchar(max) NULL,
        [Vision] nvarchar(max) NULL,
        [VisionAr] nvarchar(max) NULL,
        [Message] nvarchar(max) NULL,
        [MessageAr] nvarchar(max) NULL,
        [History] nvarchar(max) NULL,
        [HistoryAr] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [AddressAr] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [PhoneNumbermain] nvarchar(max) NULL,
        [PhoneNumberSecond] nvarchar(max) NULL,
        [PhoneNumberThird] nvarchar(max) NULL,
        [MapPath] nvarchar(max) NULL,
        [AboutUs] nvarchar(max) NULL,
        [AboutUsAr] nvarchar(max) NULL,
        [FacebookPath] nvarchar(max) NULL,
        [TwitterPath] nvarchar(max) NULL,
        [YoutubePath] nvarchar(max) NULL,
        [LinkedInPath] nvarchar(max) NULL,
        [JobTimeDetails] nvarchar(max) NULL,
        CONSTRAINT [PK_GeneralSettings] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [Hospitals] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [Name] nvarchar(max) NULL,
        [NameAr] nvarchar(max) NULL,
        [description] nvarchar(max) NULL,
        [descriptionAr] nvarchar(max) NULL,
        CONSTRAINT [PK_Hospitals] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [News] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [MainPhoto] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [TitleAr] nvarchar(max) NULL,
        [description] nvarchar(max) NULL,
        [descriptionAr] nvarchar(max) NULL,
        CONSTRAINT [PK_News] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [Roles] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [NameAr] nvarchar(max) NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [Sliders] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [Path] nvarchar(max) NULL,
        [Text] nvarchar(max) NULL,
        [TextAr] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [TitleAr] nvarchar(max) NULL,
        CONSTRAINT [PK_Sliders] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [User] (
        [Id] uniqueidentifier NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [MiddelName] nvarchar(max) NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [Departments] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [Name] nvarchar(max) NULL,
        [NameAr] nvarchar(max) NULL,
        [description] nvarchar(max) NULL,
        [descriptionAr] nvarchar(max) NULL,
        [PhotoMain] nvarchar(max) NULL,
        [HospitalId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Departments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Departments_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [NewsImages] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [Path] nvarchar(max) NULL,
        [isMain] bit NOT NULL,
        [NewsId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_NewsImages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_NewsImages_News_NewsId] FOREIGN KEY ([NewsId]) REFERENCES [News] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] uniqueidentifier NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] uniqueidentifier NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] uniqueidentifier NOT NULL,
        [RoleId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] uniqueidentifier NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [DepartmentImages] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [Path] nvarchar(max) NULL,
        [isMain] bit NOT NULL,
        [DepartmentId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_DepartmentImages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DepartmentImages_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [DepartmentServices] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [Name] nvarchar(max) NULL,
        [NameAr] nvarchar(max) NULL,
        [DepartmentId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_DepartmentServices] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DepartmentServices_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE TABLE [Doctors] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NOT NULL,
        [Name] nvarchar(max) NULL,
        [NameAr] nvarchar(max) NULL,
        [Special] nvarchar(max) NULL,
        [SpecialAr] nvarchar(max) NULL,
        [IsConsultant] bit NOT NULL,
        [Degree] nvarchar(max) NULL,
        [DegreeAr] nvarchar(max) NULL,
        [University] nvarchar(max) NULL,
        [UniversityAr] nvarchar(max) NULL,
        [Job] nvarchar(max) NULL,
        [JobAr] nvarchar(max) NULL,
        [Skills] nvarchar(max) NULL,
        [SkillsAr] nvarchar(max) NULL,
        [PhotoPath] nvarchar(max) NULL,
        [DepartmentId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Doctors] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Doctors_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NameAr', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    INSERT INTO [Roles] ([Id], [ConcurrencyStamp], [Name], [NameAr], [NormalizedName])
    VALUES ('b22698b1-42a2-4115-9634-1c2d1e2ac5f8', N'26b7f116-d687-4ef3-8828-5a3d82daa6ad', N'admin', N'أدمن', N'ADMIN');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NameAr', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NameAr', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    INSERT INTO [Roles] ([Id], [ConcurrencyStamp], [Name], [NameAr], [NormalizedName])
    VALUES ('b22694b8-42a2-4115-9631-1c2d1e2ac5f7', N'70d1ed5e-1e7d-4b3a-98ad-c6ff6def363e', N'user', N'مستخدم', N'USER');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NameAr', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'MiddelName', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[User]'))
        SET IDENTITY_INSERT [User] ON;
    INSERT INTO [User] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [FirstName], [LastName], [LockoutEnabled], [LockoutEnd], [MiddelName], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES ('c22694b8-42a2-4115-9631-1c2d1e2ac5f7', 0, N'9c6d173c-238d-4577-8667-f6af5f497fb5', N'Admin@eg.com', CAST(1 AS bit), N'admin', N'admin', CAST(0 AS bit), NULL, N'admin', N'ADMIN@EG.COM', N'ADMIN', N'AQAAAAEAACcQAAAAECHFuZY140a+UkLosi5JNJzF0uwrmSJkvHEeEVAFYeAP2p8uXgNmpVgSo7saRIPqng==', N'01027409328', CAST(1 AS bit), N'00000000-0000-0000-0000-000000000000', CAST(0 AS bit), N'admin');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'MiddelName', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[User]'))
        SET IDENTITY_INSERT [User] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'RoleId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    INSERT INTO [AspNetUserRoles] ([UserId], [RoleId])
    VALUES ('c22694b8-42a2-4115-9631-1c2d1e2ac5f7', 'b22698b1-42a2-4115-9634-1c2d1e2ac5f8');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'RoleId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE INDEX [IX_DepartmentImages_DepartmentId] ON [DepartmentImages] ([DepartmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE INDEX [IX_Departments_HospitalId] ON [Departments] ([HospitalId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE INDEX [IX_DepartmentServices_DepartmentId] ON [DepartmentServices] ([DepartmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE INDEX [IX_Doctors_DepartmentId] ON [Doctors] ([DepartmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE INDEX [IX_NewsImages_NewsId] ON [NewsImages] ([NewsId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [Roles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE INDEX [EmailIndex] ON [User] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [User] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210605145538_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210605145538_initial', N'3.1.15');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210606202643_setting-data')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AboutUs', N'AboutUsAr', N'AboutUsDescription', N'AboutUsDescriptionAr', N'Address', N'AddressAr', N'AdminSiteName', N'AdminSiteNameAr', N'CreatedDate', N'Email', N'FacebookPath', N'History', N'HistoryAr', N'JobTimeDetails', N'LastEditDate', N'LinkedInPath', N'ManegerHead', N'ManegerHeadAr', N'ManegerName', N'ManegerNameAr', N'ManegerPhotoPath', N'ManegerWord', N'ManegerWordAr', N'MapPath', N'Message', N'MessageAr', N'PhoneNumberSecond', N'PhoneNumberThird', N'PhoneNumbermain', N'SiteLogoPath', N'SiteName', N'SiteNameAr', N'TwitterPath', N'Value', N'ValueAr', N'VideoPath', N'Vision', N'VisionAr', N'YoutubePath') AND [object_id] = OBJECT_ID(N'[GeneralSettings]'))
        SET IDENTITY_INSERT [GeneralSettings] ON;
    INSERT INTO [GeneralSettings] ([Id], [AboutUs], [AboutUsAr], [AboutUsDescription], [AboutUsDescriptionAr], [Address], [AddressAr], [AdminSiteName], [AdminSiteNameAr], [CreatedDate], [Email], [FacebookPath], [History], [HistoryAr], [JobTimeDetails], [LastEditDate], [LinkedInPath], [ManegerHead], [ManegerHeadAr], [ManegerName], [ManegerNameAr], [ManegerPhotoPath], [ManegerWord], [ManegerWordAr], [MapPath], [Message], [MessageAr], [PhoneNumberSecond], [PhoneNumberThird], [PhoneNumbermain], [SiteLogoPath], [SiteName], [SiteNameAr], [TwitterPath], [Value], [ValueAr], [VideoPath], [Vision], [VisionAr], [YoutubePath])
    VALUES ('c22694b8-42a2-4115-9631-1c2d1e2ac5f7', N'In the medical complex, we focus on the quality of doctors and the best and latest services, so do not worry about any disease that affects you. Just visit us and you will see that an integrated professional team of distinguished doctors in all specialties will take care of you and heal you, God willing.', N'في المجمع الطبي  نركز على جودة الاطباء وافضل الخدمات واحدثها، لذالك لا تقلق من اي مرض يصيبك فقط قم بزيارتنا وسترى بان فريق عمل متكامل محترف من الاطباء المتميزين في كل الاختصاصات سيقومون برعايتك وشفائك بأذن الله', N'In the medical complex, we focus on the quality of doctors and the best and latest services, so do not worry about any disease that affects you. Just visit us and you will see that an integrated professional team of distinguished doctors in all specialties will take care of you and heal you, God willing.', N'في المجمع الطبي  نركز على جودة الاطباء وافضل الخدمات واحدثها، لذالك لا تقلق من اي مرض يصيبك فقط قم بزيارتنا وسترى بان فريق عمل متكامل محترف من الاطباء المتميزين في كل الاختصاصات سيقومون برعايتك وشفائك بأذن الله', N'egypt,cairo', N'القاهرة,مصر', N'name site admin', N'إسم الموقع ', '0001-01-01T00:00:00.0000000', N'ahmed.salama.ali.ramadan@gmail.com', NULL, NULL, NULL, N'9:00 AM - 2:30 PM', '0001-01-01T00:00:00.0000000', NULL, N'Doctor', NULL, N'Ahmed salama ali ramdain', NULL, N'/img/manager.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'01027409328', N'/img/log0.png', N'site name', N'أسم الموقع', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AboutUs', N'AboutUsAr', N'AboutUsDescription', N'AboutUsDescriptionAr', N'Address', N'AddressAr', N'AdminSiteName', N'AdminSiteNameAr', N'CreatedDate', N'Email', N'FacebookPath', N'History', N'HistoryAr', N'JobTimeDetails', N'LastEditDate', N'LinkedInPath', N'ManegerHead', N'ManegerHeadAr', N'ManegerName', N'ManegerNameAr', N'ManegerPhotoPath', N'ManegerWord', N'ManegerWordAr', N'MapPath', N'Message', N'MessageAr', N'PhoneNumberSecond', N'PhoneNumberThird', N'PhoneNumbermain', N'SiteLogoPath', N'SiteName', N'SiteNameAr', N'TwitterPath', N'Value', N'ValueAr', N'VideoPath', N'Vision', N'VisionAr', N'YoutubePath') AND [object_id] = OBJECT_ID(N'[GeneralSettings]'))
        SET IDENTITY_INSERT [GeneralSettings] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210606202643_setting-data')
BEGIN
    UPDATE [Roles] SET [ConcurrencyStamp] = N'133a7026-fa61-404c-92c6-29ee587a94b4'
    WHERE [Id] = 'b22694b8-42a2-4115-9631-1c2d1e2ac5f7';
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210606202643_setting-data')
BEGIN
    UPDATE [Roles] SET [ConcurrencyStamp] = N'7455750e-3a25-441c-ace7-a49eb5568da0'
    WHERE [Id] = 'b22698b1-42a2-4115-9634-1c2d1e2ac5f8';
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210606202643_setting-data')
BEGIN
    UPDATE [User] SET [ConcurrencyStamp] = N'574cac4e-c6c2-4e4a-8f12-c1cecd157b5a', [PasswordHash] = N'AQAAAAEAACcQAAAAEMeuVdD1eBOnTpajVqRD4stRnlg0Y7Alb8tNeL71WlgApNNFnpb6DRBtL/VEJ7faiw=='
    WHERE [Id] = 'c22694b8-42a2-4115-9631-1c2d1e2ac5f7';
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210606202643_setting-data')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210606202643_setting-data', N'3.1.15');
END;

GO

