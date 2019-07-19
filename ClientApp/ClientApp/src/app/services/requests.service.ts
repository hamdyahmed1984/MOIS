import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';

import { Injectable } from '@angular/core';

import { RequestModel } from '../models/RequestModel';
import { error } from '@angular/compiler/src/util';
import { catchError } from 'rxjs/operators';
import { extend } from 'webdriver-js-extender';
import { BaseService } from './base.service';
import { Helpers } from './../helpers/helpers'
import { CriminalStateRecordModel } from './../models/Documents/CriminalStateRecordModel';

@Injectable({
  providedIn: 'root'
})
export class RequestsService extends BaseService{

  //_baseUrl: string = '';

  constructor(private httpClient: HttpClient) {
    super(httpClient);
    //this._baseUrl = baseUrl;
}

  createRequest(requestModel: RequestModel): Observable<RequestModel> {
    //const headers = new HttpHeaders().set('content-type', 'application/json');
    //var body = { Id: requestModel.Id, Name: requestModel.Name, RequesterName: requestModel.RequesterName };

    //return this.httpClient.post<RequestModel>(this._baseUrl + 'api/Requests/CreateRequest', body, { headers })
    //  .subscribe(result => {
    //    console.log(result);
    //  },
    //    error => {
    //      console.error(error);
    //    });

    return this.httpClient.post<RequestModel>(this.apiUrl + 'api/requests/create-csr-request', requestModel/*, super.header()*/)
      .pipe(
        catchError(super.handleError<RequestModel>("CreateRequest", null))
      );
  }

  createCsrDoc(csrModel: CriminalStateRecordModel): Observable<CriminalStateRecordModel> {
    return this.httpClient.post<CriminalStateRecordModel>(this.apiUrl + 'api/csr/create-csr-doc', csrModel/*, super.header()*/)
      .pipe(
        catchError(super.handleError<CriminalStateRecordModel>("createCsrDoc", null))
    )
      ;
  }
}
