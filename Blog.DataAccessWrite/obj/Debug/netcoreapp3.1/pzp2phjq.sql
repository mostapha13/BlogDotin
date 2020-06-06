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

ALTER TABLE [Comments] DROP CONSTRAINT [FK_Comments_Posts_PostId];

GO

ALTER TABLE [Posts] DROP CONSTRAINT [FK_Posts_Authors_AuthoId];

GO

ALTER TABLE [Posts] DROP CONSTRAINT [FK_Posts_Subjects_SubjectId];

GO

DROP TABLE [Log];

GO

DROP INDEX [IX_Posts_AuthoId] ON [Posts];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Posts]') AND [c].[name] = N'AuthoId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Posts] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Posts] DROP COLUMN [AuthoId];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Subjects]') AND [c].[name] = N'Title');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Subjects] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Subjects] ALTER COLUMN [Title] nvarchar(max) NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Posts]') AND [c].[name] = N'Title');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Posts] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Posts] ALTER COLUMN [Title] nvarchar(max) NULL;

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Posts]') AND [c].[name] = N'Text');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Posts] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Posts] ALTER COLUMN [Text] nvarchar(max) NULL;

GO

ALTER TABLE [Posts] ADD [AuthorId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Comments]') AND [c].[name] = N'Text');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Comments] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Comments] ALTER COLUMN [Text] nvarchar(max) NULL;

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'UserName');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Authors] ALTER COLUMN [UserName] nvarchar(max) NULL;

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'LastName');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Authors] ALTER COLUMN [LastName] nvarchar(max) NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'FirstName');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Authors] ALTER COLUMN [FirstName] nvarchar(max) NULL;

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'Email');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Authors] ALTER COLUMN [Email] nvarchar(max) NULL;

GO

CREATE INDEX [IX_Posts_AuthorId] ON [Posts] ([AuthorId]);

GO

ALTER TABLE [Comments] ADD CONSTRAINT [FK_Comments_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Posts] ADD CONSTRAINT [FK_Posts_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Posts] ADD CONSTRAINT [FK_Posts_Subjects_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Subjects] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200606055620_i', N'3.1.4');

GO

