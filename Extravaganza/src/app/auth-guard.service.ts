import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(public auth: AuthService, public router: Router) {}

  canActivate(): Promise<boolean> | boolean {
    if (this.auth.isAuthenticated()) { 
      if (this.auth.userProfile) {
        let profile = this.auth.userProfile;
        return (profile && (profile['http://vondra/thanksgiving-write'] == 1 || profile['http://vondra/thanksgiving-read'] == 1))
      } else {
        return new Promise(          
          (resolve, reject) => {
            this.auth.getProfile(
              (err, profile) => {
                resolve(profile && (profile['http://vondra/thanksgiving-write'] == 1 || profile['http://vondra/thanksgiving-read'] == 1));
              }
            )
          }).then(r => {
            if (!r){
              this.router.navigate(['']);          
            }
            return r as boolean
          });
      }    
    }
    this.router.navigate(['']);
    return false;
  }
}