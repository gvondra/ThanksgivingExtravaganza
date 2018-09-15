CREATE PROCEDURE [vte].[SSP_InvitationResponse_by_InvitationId]
	@invitationId UNIQUEIDENTIFIER
AS
SELECT 
	[InvitationResponseId], [InvitationId], [IsAttending], [AttendeeCount], [Note], [CreateTimestamp]
FROM [vte].[InvitationResponse]
WHERE [InvitationId] = @invitationId
ORDER BY [CreateTimestamp] DESC
;