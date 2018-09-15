CREATE TABLE [vte].[Invitation]
(
	[InvitationId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Invitee] NVARCHAR(500) NOT NULL, 
    [Title] NVARCHAR(500) NOT NULL, 
    [Note] NVARCHAR(MAX) NOT NULL, 
    [EventDate] DATE NOT NULL, 
    [RSVPDueDate] DATE NOT NULL, 
    [CreateTimestamp] DATETIME NOT NULL, 
    [UpdateTimestamp] DATETIME NOT NULL
)
