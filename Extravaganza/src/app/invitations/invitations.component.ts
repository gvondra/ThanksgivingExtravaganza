import { Component, OnInit } from '@angular/core';
import { InvitationService } from '../services/invitation.service';
import { Invitation } from '../models/invitation';

@Component({
  selector: 'app-invitations',
  templateUrl: './invitations.component.html',
  styles: [
    'ul { list-style: circle inside; }'
  ]
})
export class InvitationsComponent implements OnInit {

  invitations: Array<Invitation> = null;

  constructor(private invitationService: InvitationService) { }

  ngOnInit(): void {
    this.invitationService.getAll()
    .then(res => {
      this.invitations = res
    });
  }

  formatDate(value: string): string {
    if (value && value != ""){
      let d: Date = new Date(value);
      return d.toLocaleDateString();
    }
    else {
      return value;
    }
  }

}
