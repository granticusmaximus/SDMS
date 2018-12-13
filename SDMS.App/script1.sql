-- Script Date: 12/13/2018 4:32 PM  - ErikEJ.SqlCeScripting version 3.5.2.75
SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [AspNetUsers] (
  [Id] nvarchar(128)  NOT NULL
, [Email] nvarchar(256)  NULL
, [EmailConfirmed] bit NOT NULL
, [PasswordHash] ntext NULL
, [SecurityStamp] ntext NULL
, [PhoneNumber] ntext NULL
, [PhoneNumberConfirmed] bit NOT NULL
, [TwoFactorEnabled] bit NOT NULL
, [LockoutEndDateUtc] datetime NULL
, [LockoutEnabled] bit NOT NULL
, [AccessFailedCount] int  NOT NULL
, [UserName] nvarchar(256)  NOT NULL
, CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY ([Id])
);
CREATE TABLE [AspNetUserLogins] (
  [LoginProvider] nvarchar(128)  NOT NULL
, [ProviderKey] nvarchar(128)  NOT NULL
, [UserId] nvarchar(128)  NOT NULL
, CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY ([LoginProvider],[ProviderKey],[UserId])
, FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
);
CREATE TABLE [AspNetUserClaims] (
  [Id] INTEGER  NOT NULL
, [UserId] nvarchar(128)  NOT NULL
, [ClaimType] ntext NULL
, [ClaimValue] ntext NULL
, CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY ([Id])
, FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
);
CREATE TABLE [AspNetRoles] (
  [Id] nvarchar(128)  NOT NULL
, [Name] nvarchar(256)  NOT NULL
, CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY ([Id])
);
CREATE TABLE [AspNetUserRoles] (
  [UserId] nvarchar(128)  NOT NULL
, [RoleId] nvarchar(128)  NOT NULL
, CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY ([UserId],[RoleId])
, FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
, FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
);
CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([UserName] ASC);
CREATE INDEX [IX_UserId] ON [AspNetUserLogins] ([UserId] ASC);
CREATE INDEX [IX_UserId] ON [AspNetUserClaims] ([UserId] ASC);
CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([Name] ASC);
CREATE INDEX [IX_RoleId] ON [AspNetUserRoles] ([RoleId] ASC);
CREATE INDEX [IX_UserId] ON [AspNetUserRoles] ([UserId] ASC);
COMMIT;

