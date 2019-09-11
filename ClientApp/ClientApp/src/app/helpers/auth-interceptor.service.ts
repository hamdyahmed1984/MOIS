import { Injectable } from '@angular/core';
import {
  HttpEvent, HttpInterceptor, HttpHandler,
  HttpRequest, HttpErrorResponse
} from '@angular/common/http';
import { throwError, Observable, BehaviorSubject } from 'rxjs';
import { catchError, filter, take, switchMap, finalize } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';
import { Helpers } from './helpers';
import { RefreshTokenModel } from '../models/Security/RefreshTokenModel';
import { RevokeTokenModel } from '../models/Security/RevokeTokenModel';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  private AUTH_HEADER = 'Authorization';
  // private token = "secrettoken";
  private refreshTokenInProgress = false;
  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  constructor(private authService: AuthService, private helpers: Helpers, private router: Router) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if (!req.headers.has('Content-Type')) {
      req = req.clone({
        headers: req.headers.set('Content-Type', 'application/json')
      });
    }

    req = this.addAuthenticationToken(req);

    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {

        // We don't want to refresh token for some requests like login or refresh token itself
        // So we verify url and we throw an error if it's the case
        if (req.url.includes('refresh-token') || req.url.includes('login')) {
          //// We do another check to see if refresh token failed
          //// In this case we want to logout user and to redirect it to login page

          // if (req.url.includes("refreshtoken")) {
          //  this.authService.Logout();
          // }
          return throwError(error);
          // return Observable.throw(error);
        }

        //// If error status is different than 401 we want to skip refresh token
        //// So we check that and throw the error if it's the case
        // if (error.status !== 401) {
        //  return Observable.throw(error);
        // }

        if (error && error.status === 401) {
          console.warn('Got 401 error, will try to refresh the token and try the same request again.');
          // 401 errors are most likely going to be because we have an expired token that we need to refresh.
          if (this.refreshTokenInProgress) {
            // If refreshTokenInProgress is true, we will wait until refreshTokenSubject has a non-null value
            // which means the new token is ready and we can retry the request again
            return this.refreshTokenSubject.pipe(
              filter(result => result !== null),
              take(1),
              switchMap(() => next.handle(this.addAuthenticationToken(req)))
            );
          } else {
            this.refreshTokenInProgress = true;

            // Set the refreshTokenSubject to null so that subsequent API calls will wait until the new token has been retrieved
            this.refreshTokenSubject.next(null);

            return this.refreshAccessToken().pipe(
              switchMap((success: boolean) => {
                if (success) {
                  console.warn('Token is refreshed successfully.');
                } else {
                  console.warn('Failed to refresh token, may be the refresh token is expired. will redirect to login page');
                }
                this.refreshTokenSubject.next(success);
                return next.handle(this.addAuthenticationToken(req));
              }),
              catchError(error2 => {
                const revokeTokenModel: RevokeTokenModel = new RevokeTokenModel();
                revokeTokenModel.Token = this.helpers.getToken().RefreshToken;
                // this.router.navigate(['/login']);
                return this.authService.Logout(revokeTokenModel);
              }),
              // When the call to refreshToken completes we reset the refreshTokenInProgress to false
              // for the next time the token needs to be refreshed
              finalize(() => this.refreshTokenInProgress = false)
            );
          }
        } else {
          return throwError(error);
        }
      })
    );
  }

  private refreshAccessToken(): Observable<any> {
    const userEmail: string = this.helpers.getUserEmail();
    const token: string = this.helpers.getToken().RefreshToken;
    const refreshTokenModel: RefreshTokenModel = new RefreshTokenModel();
    refreshTokenModel.UserEmail = userEmail;
    refreshTokenModel.Token = token;
    return this.authService.refreshToken(refreshTokenModel)
    //  .pipe(
    //  catchError(error => {
    //    console.log('hamada');
    //    let revokeTokenModel: RevokeTokenModel = new RevokeTokenModel();
    //    revokeTokenModel.Token = token;
    //    this.router.navigate(['/login']);
    //    return <any>this.authService.Logout(revokeTokenModel);
    //  })
    // )
      ;
  }

  private addAuthenticationToken(request: HttpRequest<any>): HttpRequest<any> {
    // If we do not have a token yet then we should not set the header.
    // Here we could first retrieve the token from where we store it.
    if (!this.helpers.isAuthenticated()) {
      return request;
    }
    //// If you are calling an outside domain then do not add the token.
    // if (!request.url.match(/www.mydomain.com\//)) {
    //  return request;
    // }
    return request.clone({
      headers: request.headers.set(this.AUTH_HEADER, 'Bearer ' + this.helpers.getToken().AccessToken)
    });
  }
}
