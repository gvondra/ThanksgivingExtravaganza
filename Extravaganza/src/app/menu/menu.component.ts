import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  showInvitations: boolean = false;
  profile: any = null;

  constructor(public auth: AuthService) { }

  ngOnInit() {
    this.checkAuth();
    this.auth.logObservable.subscribe(() => { this.checkAuth() })    
  }

  private checkAuth() {
    this.showInvitations = false;
    if (this.auth.isAuthenticated()){
      if (this.auth.userProfile) {
        this.profile = this.auth.userProfile;
        this.showMenuItems(this, this.profile);
      } else {
        this.auth.getProfile((err, profile) => {
          this.profile = profile;
          this.showMenuItems(this, this.profile);
        });
      }  
    }
  }

  private showMenuItems(context: any, profile: any) : void {
    if (profile && profile['http://vondra/thanksgiving-read'] == 1){
      context.showInvitations = true;
    }
  }

}
