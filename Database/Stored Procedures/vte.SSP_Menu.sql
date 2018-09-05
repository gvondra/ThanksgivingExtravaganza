CREATE PROCEDURE [vte].[SSP_Menu]
	@id int
AS

SELECT 
    [MenuId], 
    [Title], 
    [Description], 
    [SortOrder], 
    [CreateTimestamp], 
    [UpdateTimestamp]
FROM [vte].[Menu]
WHERE [MenuId] = @id
ORDER BY [SortOrder]
;
