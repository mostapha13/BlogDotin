IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Authors] (
    [Id] bigint NOT NULL IDENTITY,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [FirstName] nvarchar(250) NOT NULL,
    [LastName] nvarchar(250) NOT NULL,
    [UserName] nvarchar(250) NOT NULL,
    [Email] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Subjects] (
    [Id] bigint NOT NULL IDENTITY,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [Title] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_Subjects] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Posts] (
    [Id] bigint NOT NULL IDENTITY,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [Title] nvarchar(250) NOT NULL,
    [SubjectId] bigint NOT NULL,
    [Text] nvarchar(max) NOT NULL,
    [AuthoId] bigint NOT NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Posts_Authors_AuthoId] FOREIGN KEY ([AuthoId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Posts_Subjects_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Subjects] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Comments] (
    [Id] bigint NOT NULL IDENTITY,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [PostId] bigint NOT NULL,
    [Text] nvarchar(1500) NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comments_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Comments_PostId] ON [Comments] ([PostId]);

GO

CREATE INDEX [IX_Posts_AuthoId] ON [Posts] ([AuthoId]);

GO

CREATE INDEX [IX_Posts_SubjectId] ON [Posts] ([SubjectId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200523091348_ini_Validator', N'3.1.4');

GO

ALTER TABLE [Subjects] ADD [IsDelete] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [Posts] ADD [IsDelete] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [Comments] ADD [IsDelete] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [Authors] ADD [IsDelete] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200523094324_ini_Validator01', N'3.1.4');

GO

CREATE TABLE [Log] (
    [Id] int NOT NULL IDENTITY,
    [Message] nvarchar(max) NULL,
    [MessageTemplate] nvarchar(max) NULL,
    [Level] nvarchar(max) NULL,
    [TimeStamp] datetime2 NOT NULL,
    [Exception] nvarchar(max) NULL,
    [Properties] nvarchar(max) NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200523114231_Log', N'3.1.4');

GO

