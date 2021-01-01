import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Invitation } from '../models/invitation';
import { InvitationResponse } from '../models/invitation-response';
import { InvitationService } from '../services/invitation.service';

@Component({
  selector: 'app-invitation-rsvp',
  templateUrl: './invitation-rsvp.component.html',
  styles: [
  ]
})
export class InvitationRsvpComponent implements OnInit {

  invitation: Invitation = null;
  response: InvitationResponse = {IsAttending: false, AttendeeCount: 0} as InvitationResponse;
  rsvpMessage: string = null;

  constructor(private route: ActivatedRoute, 
    private invitationService: InvitationService) { }

  ngOnInit() {
    this.route.params
    .subscribe(params => {
      if (params['id']){
        this.invitationService.get(params['id'])
        .then(res => this.invitation = res);
      }
    });
  }

  formatDate(value: string): string {
    let result: string = value;
    if (value && value != ""){
      let dateValue: Date = new Date(value);
      result = dateValue.toLocaleDateString();
    }
    return result;
  }

  submit() {
    this.invitationService.createResponse(this.invitation.InvitationId, this.response)  
    .then(res => this.rsvpMessage = "Response saved")
    .catch(res => this.rsvpMessage = res);
  }
}
