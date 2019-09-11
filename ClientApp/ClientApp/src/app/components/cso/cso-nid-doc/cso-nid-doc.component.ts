import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LookupsService } from 'src/app/services/lookups.service';
import { RequesterNameModel } from 'src/app/models/RequestModel';
import { NidDocModel } from 'src/app/models/Documents/NidDocModel';
import { DomSanitizer } from '@angular/platform-browser';
import { CsoDocBaseComponent } from '../cso-doc-base/cso-doc-base.component';

@Component({
  selector: 'app-cso-nid-doc',
  templateUrl: './cso-nid-doc.component.html',
  styleUrls: ['./cso-nid-doc.component.css']
})
export class CsoNidDocComponent extends CsoDocBaseComponent implements OnInit {

  title = 'Nid Doc';
  nidDocModel: NidDocModel;
  docTypeCode = 'MOICSO002';

  constructor(lookupsService: LookupsService, sanitizer: DomSanitizer) {
    super(lookupsService, sanitizer);
    this.docForm = this.createFormGroup();
  }

  ngOnInit() {
    console.log(this.docTypeModel);
    this.nidDocModel = this.docTypeModel.doc;
    this.getJobTypesList();
    this.getIssueReasonsList();
    this.setFormValuesFromModel(this.nidDocModel);
    this.getDocRegulations();
    this.onFormChanges();
  }

  getDocRegulations() {
    super.getDocRegulations(this.docTypeCode, this.docForm.get('jobTypeId').value);
  }

  setDocModel() {
    this.nidDocModel.JobTypeNIDId = this.docForm.get('jobTypeId').value;
    this.nidDocModel.JobName = this.docForm.get('jobName').value;
    this.nidDocModel.NidIssueReasonId = this.docForm.get('issueReasonId').value;
    this.nidDocModel.IsFirstTime = this.docForm.get('isFirstTime').value;
    this.nidDocModel.Name = new RequesterNameModel();
    this.nidDocModel.Name.FirstName = this.docForm.get('requesterName').get('firstName').value;
    this.nidDocModel.Name.FatherName = this.docForm.get('requesterName').get('fatherName').value;
    this.nidDocModel.Name.GrandFatherName = this.docForm.get('requesterName').get('grandFatherName').value;
    this.nidDocModel.Name.FamilyName = this.docForm.get('requesterName').get('familyName').value;
    this.docTypeModel.doc = this.nidDocModel;
    this.docTypeModel.isAgreed = this.docForm.get('agreement').value;
  }

  setFormValuesFromModel(nidDocModel: NidDocModel) {
    this.docForm.patchValue({
      jobTypeId: nidDocModel.JobTypeNIDId,
      jobName: nidDocModel.JobName,
      issueReasonId: nidDocModel.NidIssueReasonId,
      isFirstTime: nidDocModel.IsFirstTime,
      agreement: this.docTypeModel.isAgreed,
      requesterName: {
        firstName: nidDocModel.Name ? nidDocModel.Name.FirstName : null,
        fatherName: nidDocModel.Name ? nidDocModel.Name.FatherName : null,
        grandFatherName: nidDocModel.Name ? nidDocModel.Name.GrandFatherName : null,
        familyName: nidDocModel.Name ? nidDocModel.Name.FamilyName : null
      }
    });
  }

  createFormGroup(): FormGroup {
    return new FormGroup({
      requesterName: new FormGroup({
        firstName: new FormControl('', [Validators.required, Validators.maxLength(20)
        ]),
        fatherName: new FormControl('', [Validators.required, Validators.maxLength(20)]),
        grandFatherName: new FormControl('', [Validators.required, Validators.maxLength(20)]),
        familyName: new FormControl('', [Validators.required, Validators.maxLength(20)])
      }),
      jobTypeId: new FormControl('', Validators.required),
      jobName: new FormControl('', Validators.required),
      issueReasonId: new FormControl('', Validators.required),
      isFirstTime: new FormControl(''),
      agreement: new FormControl('')
    });
  }
}
