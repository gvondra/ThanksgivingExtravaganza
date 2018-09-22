import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Invitation } from '../invitation';
import { InvitationService } from '../invitation.service';
@Component({
  selector: 'app-invitation',
  templateUrl: './invitation.component.html',
  styleUrls: ['./invitation.component.css'],
  providers: [ InvitationService ]
})
export class InvitationComponent implements OnInit {

  invitation: Invitation = null;
  eventDate2: string = null;
  rsvpDueDate2: string = null;
  canDelete: boolean = false;
  save: any = null;

  constructor(private route: ActivatedRoute, 
    private router: Router,
    private invitationService: InvitationService) { }

  ngOnInit() {
    this.route.params
    .subscribe(params => {
      this.canDelete = false;
      if (params['id']){
        this.save = this.update;
        this.invitationService.get(params['id'])
        .then(res => {
          this.eventDate2 = null;
          this.rsvpDueDate2 = null;
          if (res && res.EventDate && res.EventDate != "") {
            this.eventDate2 = this.getDatePart(res.EventDate);
          }
          if (res && res.RSVPDueDate && res.RSVPDueDate != "") {
            this.rsvpDueDate2 = this.getDatePart(res.RSVPDueDate);
          }
          this.invitation = res;
          this.canDelete = true;
        });
      }
      else {
        this.save = this.create;
        this.invitation = new Invitation();
      }
    });
  }

  getDatePart(value: string) {
    let result: string = value;
    if (value && value != "") {
      let i: number = value.indexOf("T");
      if (i >= 0) {
        result = value.substring(0, i);
      }
    }
    return result;
  }

  submit() {
    this.save();
  }

  update() {
    this.invitation.EventDate = this.eventDate2;
    this.invitation.RSVPDueDate = this.rsvpDueDate2;
    this.invitationService.update(this.invitation)
    .then(res => this.invitation = res);
  }

  create() {
    this.invitation.EventDate = this.eventDate2;
    this.invitation.RSVPDueDate = this.rsvpDueDate2;
    this.invitationService.create(this.invitation)
    .then(res => this.invitation = res);
    this.save = this.update;
    this.canDelete = true;
  }

  delete() {
    this.invitationService.delete(this.invitation.InvitationId)
    .then(res => this.router.navigate(["/invitations"]));
  }
}
