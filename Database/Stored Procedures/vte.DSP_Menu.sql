CREATE PROCEDURE [vte].[DSP_Menu]
	@id int
AS
BEGIN
	DELETE FROM [vte].[MenuComment] WHERE [MenuId] = @id;
	DELETE FROM [vte].[Menu] WHERE [MenuId] = @id;
END