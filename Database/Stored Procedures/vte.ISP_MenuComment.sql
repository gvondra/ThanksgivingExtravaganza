CREATE PROCEDURE [vte].[ISP_MenuComment]
	@id INT OUT,
	@timestamp DATETIME OUT,
	@menuId INT,
	@text NVARCHAR(MAX),
	@createUser NVARCHAR(250)
AS
BEGIN
	SET @timestamp = GETUTCDATE();

	INSERT INTO [vte].[MenuComment] ([MenuId], [Text], [CreateUser], [CreateTimestamp])
	VALUES (@menuId, @text, @createUser, @timestamp)
	;
	SET @id = SCOPE_IDENTITY();
END
