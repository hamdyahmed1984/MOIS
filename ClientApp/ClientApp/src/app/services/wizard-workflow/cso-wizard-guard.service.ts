import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CsoWizardWorkflowService } from './../wizard-workflow/cso-wizard-workflow.service';

@Injectable({
  providedIn: 'root'
})
export class CsoWizardGuardService implements CanActivate {

  constructor(private router: Router, private csoWizardWorkflowService: CsoWizardWorkflowService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    const path: string = next.routeConfig.path;
    // If any of the previous steps is invalid, go back to the first invalid step
    const firstPath = this.csoWizardWorkflowService.getFirstInvalidStep(path);
    if (firstPath.length > 0) {
      console.log('CSO redirected to \'' + firstPath + '\' path which it is the first invalid step.');
      const url = `cso/${firstPath}`;
      this.router.navigate([url]);
      return false;
    }

    return true;
  }
}
