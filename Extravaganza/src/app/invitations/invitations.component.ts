import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { InvitationService } from '../invitation.service';
import { Invitation } from '../invitation';
@Component({
  selector: 'app-invitations',
  templateUrl: './invitations.component.html',
  styleUrls: ['./invitations.component.css'],
  providers: [ InvitationService ]
})
export class InvitationsComponent implements OnInit {

  invitations: Array<Invitation> = null;
  showAdd: boolean = false;
  profile: any = null;

  constructor(private auth: AuthService, private invitationService: InvitationService) { }

  ngOnInit() {
    this.invitationService.getAll()
    .then(res => {
      this.invitations = res
    });
    if (this.auth.isAuthenticated()){
      if (this.auth.userProfile) {
        this.profile = this.auth.userProfile;
        this.checkClaims(this, this.profile);
      } else {
        this.auth.getProfile((err, profile) => {
          this.profile = profile;
          this.checkClaims(this, this.profile);
        });
      } 
    }    
  }

  private checkClaims(context, profile): void {
    context.showAdd = false;
    if (profile && profile['http://vondra/thanksgiving-write'] == 1 && profile['http://vondra/thanksgiving-read'] == 1){
      context.showAdd = true;
    }
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
