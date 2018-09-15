CREATE PROCEDURE [vte].[SSP_Invitation]
	@id UNIQUEIDENTIFIER
AS
SELECT 
	[InvitationId], [Invitee], [Title], [Note], [EventDate], [RSVPDueDate], [CreateTimestamp], [UpdateTimestamp]
FROM [vte].[Invitation]
WHERE [InvitationId] = @id
;
