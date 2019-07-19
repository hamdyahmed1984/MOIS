import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
import { RequestsComponent } from './components/requests/requests.component';
import { AddressGroupComponent } from './components/address-group/address-group.component';
import { LoginComponent } from './components/login/login/login.component';
import { LogoutComponent } from './components/login/logout/logout.component';
import { CsrHomeComponent } from './components/csr/csr-home/csr-home.component';
import { CsrDocComponent } from './components/csr/csr-doc/csr-doc.component';
import { CsrConfirmComponent } from './components/csr/csr-confirm/csr-confirm.component';
import { AuthGuard } from './helpers/canActivateAuthGuard';
import { CsrWizardGuard } from './services/wizard-workflow/csr-wizard-guard';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  //{ path: 'fetch-data', component: FetchDataComponent },
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
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes/*, { useHash: true }*/)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
