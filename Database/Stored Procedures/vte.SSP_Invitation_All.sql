CREATE PROCEDURE [vte].[SSP_Invitation_All]
AS
SELECT 
	[InvitationId], [Invitee], [Title], [Note], [EventDate], [RSVPDueDate], [CreateTimestamp], [UpdateTimestamp]
FROM [vte].[Invitation]
ORDER BY [EventDate] DESC, [Invitee]
;
