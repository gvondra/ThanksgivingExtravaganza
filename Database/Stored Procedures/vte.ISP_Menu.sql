CREATE PROCEDURE [vte].[ISP_Menu]
	@id INT OUT,
	@timestamp DATETIME OUT,
	@title NVARCHAR(200),
	@description NVARCHAR(MAX),
	@sortOrder INT
AS
BEGIN
	SET @timestamp = GETUTCDATE();
	INSERT INTO [vte].[Menu] ([Title], [Description], [SortOrder], [CreateTimestamp], [UpdateTimestamp])
	VALUES (@title, @description, @sortOrder, @timestamp, @timestamp)
	;
	SET @id = SCOPE_IDENTITY();
END
