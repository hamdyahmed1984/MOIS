import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs';
import { AccessTokenModel } from '../models/Security/AccessTokenModel'

@Injectable()
export class Helpers {
  private authenticationChanged = new Subject<boolean>();

  constructor() {  }

  public isAuthenticated(): boolean {
    return (!(window.localStorage['mois-requests-api-token'] === undefined ||
      window.localStorage['mois-requests-api-token'] === null ||
      window.localStorage['mois-requests-api-token'] === 'null' ||
      window.localStorage['mois-requests-api-token'] === 'undefined' ||
      window.localStorage['mois-requests-api-token'] === '' ||
      !window.localStorage['mois-requests-api-token']));
  }

  public isAuthenticationChanged(): any {
    return this.authenticationChanged.asObservable();
  }

  public getToken(): AccessTokenModel {
    if (window.localStorage['mois-requests-api-token'] === undefined ||
      window.localStorage['mois-requests-api-token'] === null ||
      window.localStorage['mois-requests-api-token'] === 'null' ||
      window.localStorage['mois-requests-api-token'] === 'undefined' ||
      window.localStorage['mois-requests-api-token'] === '' ||
      !window.localStorage['mois-requests-api-token']) {
      return new AccessTokenModel();
    }

    let accessTokenModel = JSON.parse(window.localStorage['mois-requests-api-token']);
    //let accessTokenModel: AccessTokenModel = new AccessTokenModel();
    //console.log('token::::');
    //console.log(accessTokenModel);
    //accessTokenModel.AccessToken = obj.AccessToken;
    //accessTokenModel.RefreshToken = obj.RefreshToken;
    //accessTokenModel.Expiration = obj.Expiration;
    return accessTokenModel;
  }

  public setToken(accessTokenModel: AccessTokenModel): void {
    this.setStorageToken(JSON.stringify(accessTokenModel));
  }

  public setUserEmail(userEmail:string): void {
    window.localStorage['mois-requests-api-userEmail'] = userEmail;
  }

  public getUserEmail(): string {
    return window.localStorage['mois-requests-api-userEmail'];
  }

  public failToken(): void {
    this.setStorageToken(undefined);
  }

  public logout(): void {
    this.setStorageToken(undefined);
  }

  private setStorageToken(value: any): void {
    window.localStorage['mois-requests-api-token'] = value;
    this.authenticationChanged.next(this.isAuthenticated());
  }

  public isAccessTokenExpired(accessToken?: AccessTokenModel) {
    if (accessToken == null)
      accessToken = this.getToken();
    if (this.getCurrentDateTicks() > accessToken.Expiration)
      return true;
    return false;
  }

  private getCurrentDateTicks() {
    /*
     *The JavaScript Date type's origin is the Unix epoch: midnight on 1 January 1970.
     * The .NET DateTime type's origin is midnight on 1 January 0001.
     * You can translate a JavaScript Date object to .NET ticks as follows:
     * */
    let currentDate = new Date();
    // the number of .net ticks at the unix epoch
    let epochTicks = 621355968000000000;
    // there are 10000 .net ticks per millisecond
    let ticksPerMillisecond = 10000;
    // calculate the total number of .net ticks for your date
    let currentTicks = epochTicks + (currentDate.getTime() * ticksPerMillisecond);
    return currentTicks;
  }
}
