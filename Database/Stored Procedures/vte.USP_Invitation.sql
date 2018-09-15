CREATE PROCEDURE [vte].[USP_Invitation]
	@id UNIQUEIDENTIFIER,
	@timestamp DATETIME OUT,
	@invitee NVARCHAR(500),
	@title NVARCHAR(500),
	@note NVARCHAR(MAX),
	@eventDate DATE,
	@rsvpDue DATE
AS
BEGIN
	SET @timestamp = GETUTCDATE();
	UPDATE [vte].[Invitation]
	SET
		[Invitee] = @invitee, 
		[Title] = @title, 
		[Note] = @note, 
		[EventDate] = @eventDate, 
		[RSVPDueDate] = @rsvpDue, 
		[UpdateTimestamp] = @timestamp
	WHERE [InvitationId] = @id
	;
END
