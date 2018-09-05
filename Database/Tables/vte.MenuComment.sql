CREATE TABLE [vte].[MenuComment]
(
	[MenuCommentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MenuId] INT NOT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [CreateUser] NVARCHAR(250) NOT NULL, 
    [CreateTimestamp] DATETIME NOT NULL, 
    CONSTRAINT [FK_MenuComment_To_Menu] FOREIGN KEY ([MenuId]) REFERENCES [vte].[Menu]([MenuId])
)

GO

CREATE INDEX [IX_MenuComment_MenuId] ON [vte].[MenuComment] ([MenuId])
