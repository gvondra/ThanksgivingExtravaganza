CREATE PROCEDURE [vte].[SSP_Menu_All]
AS
SELECT 
    [MenuId], 
    [Title], 
    [Description], 
    [SortOrder], 
    [CreateTimestamp], 
    [UpdateTimestamp]
FROM [vte].[Menu]
ORDER BY [SortOrder]
;
