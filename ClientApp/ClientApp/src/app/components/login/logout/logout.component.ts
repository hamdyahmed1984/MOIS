import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Helpers } from '../../../helpers/helpers';
import { AuthService } from '../../../services/auth.service';
import { RevokeTokenModel } from '../../../models/Security/RevokeTokenModel'

@Component({
  selector: 'app-logout',
  template: '<ng-content></ng-content>'
})

export class LogoutComponent implements OnInit {
  constructor(private router: Router, private helpers: Helpers, private authService: AuthService) { }

  ngOnInit() {
    let revokeTokenModel: RevokeTokenModel = new RevokeTokenModel();
    revokeTokenModel.Token = this.helpers.getToken().RefreshToken;    
    //this.helpers.logout();
    this.authService.Logout(revokeTokenModel).subscribe();
    this.router.navigate(['/login']);
  }
}
