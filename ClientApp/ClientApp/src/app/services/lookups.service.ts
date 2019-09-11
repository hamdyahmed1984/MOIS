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
import { RegulationModel } from '../models/Lookups/RegulationModel';

@Injectable({
  providedIn: 'root'
})
export class LookupsService extends BaseService {

  constructor(private httpClient: HttpClient) {
    super(httpClient);
  }

  getGenders(): Observable<LookupBaseModel[]> {
    return this.httpClient.get<LookupBaseModel[]>(this.apiUrl + 'api/lookups/genders')
      .pipe(catchError(super.handleError<LookupBaseModel[]>('LookupsService.getGenders')));
  }

  getJobTypesForNid(): Observable<LookupBaseModel[]> {
    return this.httpClient.get<LookupBaseModel[]>(this.apiUrl + 'api/lookups/nid-job-types')
      .pipe(catchError(super.handleError<LookupBaseModel[]>('LookupsService.getJobTypesForNid')));
  }

  getIssuingReasonsForNid(): Observable<LookupBaseModel[]> {
    return this.httpClient.get<LookupBaseModel[]>(this.apiUrl + 'api/lookups/nid-issue-reasons')
      .pipe(catchError(super.handleError<LookupBaseModel[]>('LookupsService.getIssuingReasonsForNid')));
  }

  getRelations(): Observable<LookupBaseModel[]> {
    return this.httpClient.get<LookupBaseModel[]>(this.apiUrl + 'api/lookups/relations')
      .pipe(catchError(super.handleError<LookupBaseModel[]>('LookupsService.getRelations')));
  }

  getGovernorates(): Observable<LookupBaseModel[]> {
    return this.httpClient.get<LookupBaseModel[]>(this.apiUrl + 'api/lookups/govs')
      .pipe(catchError(super.handleError<LookupBaseModel[]>('LookupsService.getGovernorates')));
  }

  getPoliceDepartments(): Observable<PoliceDepartmentModel[]> {
    return this.httpClient.get<PoliceDepartmentModel[]>(this.apiUrl + 'api/lookups/police-depts')
      .pipe(catchError(super.handleError<PoliceDepartmentModel[]>('LookupsService.getPoliceDepartments')));
  }

  getPostalCodes(): Observable<PostalCodeModel[]> {
    return this.httpClient.get<PostalCodeModel[]>(this.apiUrl + 'api/lookups/postal-codes')
      .pipe(catchError(super.handleError<PostalCodeModel[]>('LookupsService.getPostalCodes')));
  }

  getRegulations(): Observable<RegulationModel[]> {
    return this.httpClient.get<RegulationModel[]>(this.apiUrl + 'api/lookups/regulations')
      .pipe(catchError(super.handleError<RegulationModel[]>('LookupsService.getRegulations')));
  }
}
