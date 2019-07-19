import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { Helpers } from '../../../helpers/helpers';
import { UserCredentialsModel } from '../../../models/Security/UserCredentialsModel'
//import { NgForm } from '@angular/forms';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl('')
  });

  constructor(private helpers: Helpers, private router: Router, private authService: AuthService) { }

  ngOnInit() { }

  login(): void {
    //let authValues = { "Email": loginFrom.value.Email, "Password": loginFrom.value.Password };
    var userCredsModel: UserCredentialsModel = new UserCredentialsModel();
    userCredsModel.Email = this.loginForm.get('email').value;//loginFrom.value.Email;
    userCredsModel.Password = this.loginForm.get('password').value;//loginFrom.value.Password;
    //console.warn(userCredsModel);
    this.authService.Login(userCredsModel).subscribe(token => {
      this.helpers.setToken(token);
      this.helpers.setUserEmail(userCredsModel.Email);
      this.router.navigate(['/requests']);
    });
  }
} 
