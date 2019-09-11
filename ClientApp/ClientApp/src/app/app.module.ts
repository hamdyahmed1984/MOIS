import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
// import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module'; /* Routing Module */

import { Helpers } from './helpers/helpers';
import { AuthInterceptor } from './helpers/auth-interceptor.service';
import { AppConfig } from './config/config';
import { AuthGuard } from './helpers/canActivateAuthGuard';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
// import { FetchDataComponent } from './components/fetch-data/fetch-data.component';

import { RequestsComponent } from './components/requests/requests.component';
import { LoginComponent } from './components/login/login/login.component';
import { LogoutComponent } from './components/login/logout/logout.component';
import { AddressComponent } from './components/address/address.component';
import { AddressGroupComponent } from './components/address-group/address-group.component';

import { CsrHomeComponent } from './components/csr/csr-home/csr-home.component';
import { WizardNavbarCsrComponent } from './components/csr/wizard-navbar-csr/wizard-navbar-csr.component';
import { CsrDocComponent } from './components/csr/csr-doc/csr-doc.component';
import { CsrConfirmComponent } from './components/csr/csr-confirm/csr-confirm.component';
import { CsrFormDataService } from './services/csr-form-data.service';

import { CsoHomeComponent } from './components/cso/cso-home/cso-home.component';
import { WizardNavbarCsoComponent } from './components/cso/wizard-navbar-cso/wizard-navbar-cso.component';
import { CsoDocsComponent } from './components/cso/cso-docs/cso-docs.component';
import { CsoConfirmComponent } from './components/cso/cso-confirm/cso-confirm.component';
import { CsoFormDataService } from './services/cso-form-data.service';
import { CsoBirthDocComponent } from './components/cso/cso-birth-doc/cso-birth-doc.component';
import { CsoDeathDocComponent } from './components/cso/cso-death-doc/cso-death-doc.component';
import { CsoMarriageDocComponent } from './components/cso/cso-marriage-doc/cso-marriage-doc.component';
import { CsoDivorceDocComponent } from './components/cso/cso-divorce-doc/cso-divorce-doc.component';
import { CsoNidDocComponent } from './components/cso/cso-nid-doc/cso-nid-doc.component';
import { CsoDocBaseComponent } from './components/cso/cso-doc-base/cso-doc-base.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    // FetchDataComponent,
    RequestsComponent,
    LoginComponent,
    LogoutComponent,
    AddressComponent,
    WizardNavbarCsrComponent,
    CsrDocComponent,
    CsrConfirmComponent,
    CsrHomeComponent,
    AddressGroupComponent,
    CsoHomeComponent,
    WizardNavbarCsoComponent,
    CsoDocsComponent,
    CsoConfirmComponent,
    CsoBirthDocComponent,
    CsoDeathDocComponent,
    CsoMarriageDocComponent,
    CsoDivorceDocComponent,
    CsoNidDocComponent,
    CsoDocBaseComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    // ArchwizardModule,
    // RouterModule.forRoot([
    //  { path: '', component: HomeComponent, pathMatch: 'full' },
    //  { path: 'counter', component: CounterComponent },
    //  //{ path: 'fetch-data', component: FetchDataComponent },
    //  { path: 'requests', component: RequestsComponent, canActivate: [AuthGuard] },
    //  { path: 'login', component: LoginComponent },
    //  { path: 'logout', component: LogoutComponent },
    // ])
  ],
  providers: [
    AuthGuard,
    Helpers,
    AppConfig,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: CsrFormDataService, useClass: CsrFormDataService },
    { provide: CsoFormDataService, useClass: CsoFormDataService }
  ],
  entryComponents: [
    CsoBirthDocComponent,
    CsoDeathDocComponent,
    CsoMarriageDocComponent,
    CsoDivorceDocComponent,
    CsoNidDocComponent ],
  bootstrap: [AppComponent]
})
export class AppModule { }
