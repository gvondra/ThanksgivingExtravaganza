CREATE TABLE [vte].[InvitationResponse]
(
	[InvitationResponseId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InvitationId] UNIQUEIDENTIFIER NOT NULL, 
    [IsAttending] BIT NULL, 
    [AttendeeCount] SMALLINT NULL, 
    [Note] NVARCHAR(MAX) NOT NULL, 
    [CreateTimestamp] DATETIME NOT NULL
    CONSTRAINT [FK_InvitationResponse_To_Invitation] FOREIGN KEY ([InvitationId]) REFERENCES [vte].[Invitation]([InvitationId])
)

GO

CREATE INDEX [IX_InvitationResponse_InvitationId] ON [vte].[InvitationResponse] ([InvitationId])
