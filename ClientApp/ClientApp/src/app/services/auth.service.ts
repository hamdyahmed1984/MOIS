import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
//import { of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { BaseService } from './base.service';
//import { Token } from '../models/token';
import { Helpers } from '../helpers/helpers';
import { AccessTokenModel } from '../models/Security/AccessTokenModel'
import { UserCredentialsModel } from '../models/Security/UserCredentialsModel'
import { RevokeTokenModel } from '../models/Security/RevokeTokenModel'
import { RefreshTokenModel } from '../models/Security/RefreshTokenModel'
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthService extends BaseService {

  public errorMessage: string;
  constructor(private httpClient: HttpClient, private router: Router) {
    super(httpClient);
  }

  Login(userCredsModel: UserCredentialsModel): Observable<AccessTokenModel> {
    return this.httpClient.post<AccessTokenModel>(this.apiUrl + 'api/login', userCredsModel, super.header()).pipe(
      catchError(super.handleError<AccessTokenModel>("AuthService.Login"))
    );
  }

  Logout(revokeTokenModel: RevokeTokenModel): Observable<any> {
    return this.httpClient.post(this.apiUrl + 'api/token/revoke', revokeTokenModel, super.header()).pipe(
      map(result => this.router.navigate(['/login'])),
      catchError(super.handleError("AuthService.Logout"))
    );
  }

  RefreshToken(refreshTokenModel: RefreshTokenModel): Observable<any> {
    return this.httpClient.post(this.apiUrl + 'api/token/refresh', refreshTokenModel, super.header()).pipe(
      catchError(super.handleError("AuthService.RefreshToken"))
    );
  }
}
