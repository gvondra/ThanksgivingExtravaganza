import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { FoodMenu } from '../food-menu';
import { FoodMenuService } from '../food-menu.service';

@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  styleUrls: ['./food.component.css'],
  providers: [ FoodMenuService ]
})
export class FoodComponent implements OnInit {

  menuItems: Array<FoodMenu> = null;
  profile: any = null;
  canWrite: boolean = false;
  constructor(private auth: AuthService, private menuService: FoodMenuService) { }

  ngOnInit() {
    if (this.auth.isAuthenticated()){
      if (this.auth.userProfile) {
        this.profile = this.auth.userProfile;
        if (this.profile && this.profile['http://vondra/thanksgiving-write'] == 1 && this.profile['http://vondra/thanksgiving-read'] == 1){
          this.canWrite = true;
        }
        console.log(this.profile);
      } else {
        this.auth.getProfile((err, profile) => {
          this.profile = profile;
          if (this.profile && this.profile['http://vondra/thanksgiving-write'] == 1 && this.profile['http://vondra/thanksgiving-read'] == 1){
            this.canWrite = true;
          }
          console.log(this.profile);
        });
      }      
    }
    this.menuService.getAll()
    .then(res => this.menuItems = res);
  }

}
