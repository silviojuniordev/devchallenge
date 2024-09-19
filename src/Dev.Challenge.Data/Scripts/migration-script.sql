IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE DATABASE DevChallenge
GO

CREATE TABLE [Historic] (
    [Id] uniqueidentifier NOT NULL,
    [OldField] varchar(100) NOT NULL,
    [NewField] varchar(200) NOT NULL,
    [OperationType] varchar(50) NOT NULL,
    [RegisterDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [User] varchar(50) NOT NULL,
    CONSTRAINT [PK_Historic] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Projects] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    [Description] varchar(200) NOT NULL,
    [RegisterDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Tasks] (
    [Id] uniqueidentifier NOT NULL,
    [ProjectId] uniqueidentifier NOT NULL,
    [Description] varchar(200) NOT NULL,
    [MaturityDate] date NOT NULL,
    [Status] int NOT NULL,
    [Priority] int NOT NULL,
    [Active] bit NOT NULL,
    [RegisterDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [AssignedUser] varchar(50) NOT NULL,
    CONSTRAINT [PK_Tasks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tasks_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [TaskComments] (
    [Id] uniqueidentifier NOT NULL,
    [TaskingId] uniqueidentifier NOT NULL,
    [Description] varchar(200) NOT NULL,
    [RegisterDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [Active] bit NOT NULL,
    CONSTRAINT [PK_TaskComments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TaskComments_Tasks_TaskingId] FOREIGN KEY ([TaskingId]) REFERENCES [Tasks] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_TaskComments_TaskingId] ON [TaskComments] ([TaskingId]);
GO

CREATE INDEX [IX_Tasks_ProjectId] ON [Tasks] ([ProjectId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240905190459_InitialCreate', N'8.0.8');
GO

COMMIT;
GO

