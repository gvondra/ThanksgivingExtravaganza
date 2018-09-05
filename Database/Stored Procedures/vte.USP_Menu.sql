CREATE PROCEDURE [vte].[USP_Menu]
	@id INT,
	@timestamp DATETIME OUT,
	@title NVARCHAR(200),
	@description NVARCHAR(MAX),
	@sortOrder INT
AS
BEGIN
	DECLARE @currentSort INT;
	SET @timestamp = GETUTCDATE();
	
	-- is the proposed sort order in use?
	IF 0 < (SELECT COUNT(1) FROM [vte].[Menu] WHERE [SortOrder] = @sortOrder)
	BEGIN
		SELECT @currentSort = [SortOrder] FROM [vte].[Menu] WHERE [MenuId] = @id;
		-- Moving the item up in the list
		IF @sortOrder < @currentSort
		BEGIN
			UPDATE [vte].[Menu]
			SET 
				[SortOrder] = [SortOrder] + 1, 
				[UpdateTimestamp] = @timestamp
			WHERE 
				[SortOrder] >= @sortOrder
				AND [SortOrder] <= @currentSort
				AND [MenuId] <> @id;
		END
	
		-- Moving the item down in the list
		IF @sortOrder > @currentSort
		BEGIN
			UPDATE [vte].[Menu]
			SET 
				[SortOrder] = [SortOrder] - 1, 
				[UpdateTimestamp] = @timestamp
			WHERE 
				[SortOrder] <= @sortOrder
				AND [SortOrder] >= @currentSort
				AND [MenuId] <> @id;
		END
	END	

	UPDATE [vte].[Menu] 
	SET
		[Title] = @title, 
		[Description] = @description, 
		[SortOrder] = @sortOrder, 
		[UpdateTimestamp] = @timestamp
	WHERE [MenuId] = @id
	;
END
