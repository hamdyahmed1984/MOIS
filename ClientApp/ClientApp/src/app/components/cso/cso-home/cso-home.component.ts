import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CsoWizardWorkflowService } from './../../../services/wizard-workflow/cso-wizard-workflow.service';

@Component({
  selector: 'app-cso-home',
  templateUrl: './cso-home.component.html',
  styleUrls: ['./cso-home.component.css']
})
export class CsoHomeComponent implements OnInit {

  constructor(private router: Router, private csoWizardWorkflowService: CsoWizardWorkflowService) { }

  ngOnInit() {
    const firstPath = this.csoWizardWorkflowService.getFirstInvalidStep('');
    console.log('CsoHomeComponent redirected to \'' + firstPath + '\' path which it is the first invalid step.');
    const url = `cso/${firstPath}`;
    this.router.navigate([url]);
  }

}
