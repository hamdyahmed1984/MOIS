import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
import { RequestsComponent } from './components/requests/requests.component';
import { AddressGroupComponent } from './components/address-group/address-group.component';
import { LoginComponent } from './components/login/login/login.component';
import { LogoutComponent } from './components/login/logout/logout.component';

import { AuthGuard } from './helpers/canActivateAuthGuard';

import { CsrHomeComponent } from './components/csr/csr-home/csr-home.component';
import { CsrDocComponent } from './components/csr/csr-doc/csr-doc.component';
import { CsrConfirmComponent } from './components/csr/csr-confirm/csr-confirm.component';
import { CsrWizardGuard } from './services/wizard-workflow/csr-wizard-guard';

import { CsoHomeComponent } from './components/cso/cso-home/cso-home.component';
import { CsoDocsComponent } from './components/cso/cso-docs/cso-docs.component';
import { CsoConfirmComponent } from './components/cso/cso-confirm/cso-confirm.component';
import { CsoWizardGuardService } from './services/wizard-workflow/cso-wizard-guard.service';
import { CsoDocsDetailsComponent } from './components/cso/cso-docs-details/cso-docs-details.component';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  // { path: 'fetch-data', component: FetchDataComponent },
  { path: 'requests', component: RequestsComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  {
    path: 'csr',
    component: CsrHomeComponent,
    children: [
      { path: 'requester', component: RequestsComponent, canActivate: [CsrWizardGuard] },
      { path: 'address', component: AddressGroupComponent, canActivate: [CsrWizardGuard] },
      { path: 'doc', component: CsrDocComponent, canActivate: [CsrWizardGuard]/*, outlet: 'csr-outlet'*/ },
      { path: 'confirm', component: CsrConfirmComponent, canActivate: [CsrWizardGuard] }
    ]
  },
  {
    path: 'cso',
    component: CsoHomeComponent,
    children: [
      { path: 'requester', component: RequestsComponent, canActivate: [CsoWizardGuardService] },
      { path: 'address', component: AddressGroupComponent, canActivate: [CsoWizardGuardService] },
      { path: 'docs', component: CsoDocsComponent, canActivate: [CsoWizardGuardService]/*, outlet: 'csr-outlet'*/ },
      { path: 'docs-details', component: CsoDocsDetailsComponent, canActivate: [CsoWizardGuardService] },
      { path: 'confirm', component: CsoConfirmComponent, canActivate: [CsoWizardGuardService] }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes/*, { useHash: true }*/)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
