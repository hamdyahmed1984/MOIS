import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CsrWizardWorkflowService } from './../wizard-workflow/csr-wizard-workflow.service';

@Injectable({
  providedIn: 'root'
})
export class CsrWizardGuard implements CanActivate {

  constructor(private router: Router, private csrWizardWorkflowService: CsrWizardWorkflowService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    let path: string = next.routeConfig.path;
    // If any of the previous steps is invalid, go back to the first invalid step
    let firstPath = this.csrWizardWorkflowService.getFirstInvalidStep(path);
    if (firstPath.length > 0) {
      console.log("CSR redirected to '" + firstPath + "' path which it is the first invalid step.");
      let url = `csr/${firstPath}`;
      this.router.navigate([url]);
      return false;
    };

    return true;
  }
  
}
