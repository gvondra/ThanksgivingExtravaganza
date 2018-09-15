CREATE PROCEDURE [vte].[ISP_Invitation]
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
	INSERT INTO [vte].[Invitation] ([InvitationId], [Invitee], [Title], [Note], [EventDate], [RSVPDueDate], [CreateTimestamp], [UpdateTimestamp])
	VALUES (@id, @invitee, @title, @note, @eventDate, @rsvpDue, @timestamp, @timestamp)
	;
END
