import { Injectable, Inject, ReflectiveInjector, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { AppConfig } from '../config/config'
import { Helpers } from '../helpers/helpers';
import { AccessTokenModel } from '../models/Security/AccessTokenModel';
import { RefreshTokenModel } from '../models/Security/RefreshTokenModel'

@Injectable({ providedIn: 'root' })
export class BaseService {

  protected apiUrl: string = '';
  private helpers: Helpers;
  //private _httpClient: HttpClient;

  constructor(/*@Inject('BASE_URL') _apiUrl: string*/protected _httpClient: HttpClient) {    
    //this.apiUrl = _apiUrl;
    //We don't use constructor injection in this base class because we don't want to be forced to inject and pass all its dependencies in the all derived classes
    const injector = ReflectiveInjector.resolveAndCreate([Helpers, AppConfig]);

    //this._httpClient = injector.get(HttpClient);
    this.helpers = injector.get(Helpers);
    const config = injector.get(AppConfig);
    this.apiUrl = config.setting['apiUrl'];    
  }

  public extractData(res: Response) {
    let body = res.json();
    return body || {};
  }

  //public handleError(error: Response | any) {
  //  // In a real-world app, we might use a remote logging infrastructure
  //  let errMsg: string;
  //  if (error instanceof Response) {
  //    const body = error.json() || '';
  //    const err = body || JSON.stringify(body);
  //    errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
  //  } else {
  //    errMsg = error.message ? error.message : error.toString();
  //  }
  //  console.error(errMsg);
  //  return Observable.throw(errMsg);
  //}

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  public handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  public header() {
    //let header = new HttpHeaders({ 'Content-Type': 'application/json' });
    //if (this.helpers.isAuthenticated()) {      
    //  let storedAccessToken: AccessTokenModel = this.helpers.getToken();
    //  if (this.helpers.isAccessTokenExpired(storedAccessToken)) {
    //    let refreshTokenModel: RefreshTokenModel = this.createRefreshModel(storedAccessToken);
    //    this.refreshToken(refreshTokenModel).subscribe(accessToken => {
    //      this.setToken(accessToken);
    //      console.log('storedAccessToken');
    //      console.log(storedAccessToken);
    //      console.log('refreshedAccessToken');
    //      console.log(accessToken);
    //      header = header.append('Authorization', 'Bearer ' + accessToken.AccessToken);
    //      console.warn('token is refreshed.')
    //    });
    //  }
    //  else {
    //    header = header.append('Authorization', 'Bearer ' + storedAccessToken.AccessToken);
    //    console.log('storedAccessToken');
    //    console.log(storedAccessToken);
    //    console.warn('token is valid.')
    //  }
    //}
    //console.warn('headers:');
    //console.warn(header);
    //return { headers: header };


    let header = new HttpHeaders({ 'Content-Type': 'application/json' });
    if (this.helpers.isAuthenticated()) {
      let storedAccessToken: AccessTokenModel = this.helpers.getToken();
      header = header.append('Authorization', 'Bearer ' + storedAccessToken.AccessToken);
    }
    return { headers: header };
  }

    private createRefreshModel(storedAccessToken: AccessTokenModel) {
        let userEmail: string = this.helpers.getUserEmail();
        let token: string = storedAccessToken.RefreshToken;
        let refreshTokenModel: RefreshTokenModel = new RefreshTokenModel();
        refreshTokenModel.UserEmail = userEmail;
        refreshTokenModel.Token = token;
        return refreshTokenModel;
    }

  refreshToken(refreshTokenModel: RefreshTokenModel): Observable<AccessTokenModel> {
    let header = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this._httpClient.post<AccessTokenModel>(this.apiUrl + 'api/token/refresh', refreshTokenModel, { headers: header }).pipe(
      map((accessTokenModel: AccessTokenModel) => {
        this.helpers.setToken(accessTokenModel);
        return accessTokenModel;
      }),
      catchError(this.handleError<AccessTokenModel>("BaseService.refreshToken"))
    );
  }

  public setToken(data: AccessTokenModel) {
    this.helpers.setToken(data);
  }

  public failToken(error: Response | any) {
    this.helpers.failToken();
    //return this.handleError(Response);
    return this.handleError("failToken", Response);
  }
}
