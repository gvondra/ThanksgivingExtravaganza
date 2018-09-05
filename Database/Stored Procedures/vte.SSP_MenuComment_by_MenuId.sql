CREATE PROCEDURE [vte].[SSP_MenuComment_by_MenuId]
	@menuId INT
AS
SELECT 
    [MenuCommentId], 
    [MenuId], 
    [Text], 
    [CreateUser], 
    [CreateTimestamp]
FROM [vte].[MenuComment]
WHERE [MenuId] = @menuId
ORDER BY [MenuId] DESC
