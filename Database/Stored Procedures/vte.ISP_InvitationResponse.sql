CREATE PROCEDURE [vte].[ISP_InvitationResponse]
	@id INT OUT,
	@timestamp DATETIME OUT,
	@invitationId UNIQUEIDENTIFIER,
	@isAttending BIT,
	@attendeeCount SMALLINT,
	@note NVARCHAR(MAX)
AS
BEGIN
	SET @timestamp = GETUTCDATE();
	INSERT INTO [vte].[InvitationResponse] ([InvitationId], [IsAttending], [AttendeeCount], [Note], [CreateTimestamp])
	VALUES (@invitationId, @isAttending, @attendeeCount, @note, @timestamp)
	;
	SET @id = SCOPE_IDENTITY();
END