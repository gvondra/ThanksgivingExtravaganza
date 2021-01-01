import { InvitationResponse } from './invitation-response';
export class Invitation {
    InvitationId: string;
    Invitee: string;
    Title: string;
    Note: string;
    EventDate: string;
    RSVPDueDate: string;
    CreateTimestamp: string;
    UpdateTimestamp: string;
    Responses: InvitationResponse[];
}
