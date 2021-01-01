import { Injectable } from '@angular/core';
import { Invitation } from '../models/invitation';
import { InvitationResponse } from '../models/invitation-response';

@Injectable({
  providedIn: 'root'
})
export class InvitationService {

  constructor() { }

  getAll() : Promise<Array<Invitation>> {
    return Promise.resolve([]);
  }

  get(id: string) : Promise<Invitation> {
    return Promise.resolve(null);
  }

  create(invitation: Invitation) : Promise<Invitation> {
    return Promise.resolve(invitation);
  }

  update(invitation: Invitation) : Promise<Invitation> {
    return Promise.resolve(invitation);
  }

  delete(id: string) : Promise<string> {
    return Promise.resolve('');
  }

  createResponse(id: string, invitationResponse: InvitationResponse) : Promise<InvitationResponse> {
    return Promise.resolve(invitationResponse);
  }

  getResponses(id: string) : Promise<Array<InvitationResponse>> {
    return Promise.resolve([]);
  }
}
