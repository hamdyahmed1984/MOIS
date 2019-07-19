import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';

import { Injectable } from '@angular/core';

import { RequestModel } from '../models/RequestModel';
import { error } from '@angular/compiler/src/util';
import { catchError } from 'rxjs/operators';
import { extend } from 'webdriver-js-extender';
import { BaseService } from './base.service';
import { LookupBaseModel } from '../models/Lookups/LookupBaseModel';
import { PoliceDepartmentModel } from '../models/Lookups/PoliceDepartmentModel';
import { PostalCodeModel } from '../models/Lookups/PostalCodeModel';

@Injectable({
  providedIn: 'root'
})
export class LookupsService extends BaseService {

  constructor(private httpClient: HttpClient) {
    super(httpClient);
  }

  getGenders(): Observable<LookupBaseModel[]> {
    return this.httpClient.get<LookupBaseModel[]>(this.apiUrl + 'api/lookups/get-genders')
      .pipe(catchError(super.handleError<LookupBaseModel[]>("LookupsService.getGenders")));
  }

  getGovernorates(): Observable<LookupBaseModel[]> {
    return this.httpClient.get<LookupBaseModel[]>(this.apiUrl + 'api/lookups/get-govs')
      .pipe(catchError(super.handleError<LookupBaseModel[]>("LookupsService.getGovernorates")));
  }

  getPoliceDepartments(): Observable<PoliceDepartmentModel[]> {
    return this.httpClient.get<PoliceDepartmentModel[]>(this.apiUrl + 'api/lookups/get-police-depts')
      .pipe(catchError(super.handleError<PoliceDepartmentModel[]>("LookupsService.getPoliceDepartments")));
  }

  getPostalCodes(): Observable<PostalCodeModel[]> {
    return this.httpClient.get<PostalCodeModel[]>(this.apiUrl + 'api/lookups/get-postal-codes')
      .pipe(catchError(super.handleError<PostalCodeModel[]>("LookupsService.getPostalCodes")));
  }
}
