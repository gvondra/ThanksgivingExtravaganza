CREATE PROCEDURE [vte].[DSP_Invitation]
	@id UNIQUEIDENTIFIER
AS
BEGIN
	DELETE FROM [vte].[InvitationResponse] WHERE [InvitationId] = @id;	
	DELETE FROM [vte].[Invitation] WHERE [InvitationId] = @id;
END
