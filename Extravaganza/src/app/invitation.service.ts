import 'rxjs/add/operator/toPromise';
import { Headers, Http, URLSearchParams } from '@angular/http';
import { Injectable } from '@angular/core';
import { Invitation } from './invitation';
import { InvitationResponse } from './invitation-response';
@Injectable()
export class InvitationService {

  constructor(private http: Http) { }

  getAll() : Promise<Array<Invitation>> {
    return this.http.get("api/invitation", {
      headers: new Headers({"Authorization": `Bearer ${localStorage.getItem('access_token')}`})
    })
    .toPromise()
    .then(response => response.json() as Array<Invitation>);
  }

  get(id: string) : Promise<Invitation> {
    return this.http.get("api/invitation/" + id, {
      headers: new Headers({"Authorization": `Bearer ${localStorage.getItem('access_token')}`})
    })
    .toPromise()
    .then(response => response.json() as Invitation);
  }

  create(invitation: Invitation) : Promise<Invitation> {
    return this.http.post("api/invitation", invitation, {
      headers: new Headers({"Authorization": `Bearer ${localStorage.getItem('access_token')}`})
    })
    .toPromise()
    .then(response => response.json() as Invitation);
  }

  update(invitation: Invitation) : Promise<Invitation> {
    return this.http.put("api/invitation", invitation, {
      headers: new Headers({"Authorization": `Bearer ${localStorage.getItem('access_token')}`})
    })
    .toPromise()
    .then(response => response.json() as Invitation);
  }

  delete(id: string) : Promise<string> {
    return this.http.delete("api/invitation/" + id, {
      headers: new Headers({"Authorization": `Bearer ${localStorage.getItem('access_token')}`})
    })
    .toPromise()
    .then(response => response.text());
  }

  createResponse(id: string, invitationResponse: InvitationResponse) : Promise<InvitationResponse> {
    return this.http.post("api/invitation/" + id + "/response/", invitationResponse, {
      headers: new Headers({"Authorization": `Bearer ${localStorage.getItem('access_token')}`})
    })
    .toPromise()
    .then(response => response.json() as InvitationResponse);
  }

  getResponses(id: string) : Promise<Array<InvitationResponse>> {
    return this.http.get("api/invitation/" + id + "/response", {
      headers: new Headers({"Authorization": `Bearer ${localStorage.getItem('access_token')}`})
    })
    .toPromise()
    .then(response => response.json() as Array<InvitationResponse>);
  }
}
