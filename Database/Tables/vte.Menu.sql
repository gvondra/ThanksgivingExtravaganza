CREATE TABLE [vte].[Menu]
(
	[MenuId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [SortOrder] INT NOT NULL, 
    [CreateTimestamp] DATETIME NOT NULL, 
    [UpdateTimestamp] DATETIME NOT NULL
)
