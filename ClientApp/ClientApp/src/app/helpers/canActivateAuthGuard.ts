import { CanActivate, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Helpers } from './helpers';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private helper: Helpers) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
    //console.log("Authenticated: " + this.helper.isAuthenticated());
    //console.log("token is: " + this.helper.getToken().AccessToken);
    //console.log('Expiry: ' + this.helper.getToken().Expiration);

    //window.localStorage['token'] = undefined;
    if (!this.helper.isAuthenticated()) {
      this.router.navigate(['/login']);
      return false;
    }
    return true;
  }

}
