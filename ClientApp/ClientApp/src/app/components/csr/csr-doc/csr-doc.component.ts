import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CriminalStateRecordModel } from './../../../models/Documents/CriminalStateRecordModel';
import { CsrFormDataService } from 'src/app/services/csr-form-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-csr-doc',
  templateUrl: './csr-doc.component.html',
  styleUrls: ['./csr-doc.component.css']
})
export class CsrDocComponent implements OnInit {

  csrDocForm: FormGroup;
  title = 'Document details';
  csrDocModel: CriminalStateRecordModel;

  constructor(private router: Router, private csrFormDataService: CsrFormDataService) {
    this.csrDocForm = this.createFormGroup();
  }

  ngOnInit() {
    this.csrDocModel = this.csrFormDataService.getCsrDocModel();
    this.setFormValuesFromModel(this.csrDocModel);
  }

  set(form: any): boolean {
    if (!form.valid)
      return false;

    this.getCsrModelFromFormValues();
    this.csrFormDataService.setCsrDocModel(this.csrDocModel);
    return true;
  }

  goNext(form: any) {
    if (this.set(form))
      this.router.navigate(['/csr/confirm']);
  }

  goPrevious() {
    //if (this.set(form))
    this.router.navigate(['/csr/address']);
  }

  createFormGroup(): FormGroup {
    return new FormGroup({
      issueDestination: new FormControl('')
    });
  }

  setFormValuesFromModel(csrDocModel: CriminalStateRecordModel): any {
    this.csrDocForm.patchValue({ issueDestination: csrDocModel.IssueDestination });
    }

  getCsrModelFromFormValues(): any {
    this.csrDocModel.IssueDestination = this.csrDocForm.get('issueDestination').value;
  }
}
