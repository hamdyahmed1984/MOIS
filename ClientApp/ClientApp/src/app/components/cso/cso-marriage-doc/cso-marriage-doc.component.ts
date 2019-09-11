import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LookupsService } from 'src/app/services/lookups.service';
import { NID, RequesterNameModel } from 'src/app/models/RequestModel';
import { MarriageDocModel } from 'src/app/models/Documents/MarriageDocModel';
import { DomSanitizer } from '@angular/platform-browser';
import { CsoDocBaseComponent } from '../cso-doc-base/cso-doc-base.component';

@Component({
  selector: 'app-cso-marriage-doc',
  templateUrl: './cso-marriage-doc.component.html',
  styleUrls: ['./cso-marriage-doc.component.css']
})
export class CsoMarriageDocComponent extends CsoDocBaseComponent implements OnInit {

  title = 'Marriage Doc';
  marriageDocModel: MarriageDocModel;
  docTypeCode = 'MOICSO003';

  constructor(lookupsService: LookupsService, sanitizer: DomSanitizer) {
    super(lookupsService, sanitizer);
    this.docForm = this.createFormGroup();
  }

  ngOnInit() {
    this.numberOfCopiesList = this.getNumberOfCopiesList();
    console.log(this.docTypeModel);
    this.marriageDocModel = this.docTypeModel.doc;
    this.getRelationsList();
    this.getDocRegulations(this.docTypeCode);
    this.setFormValuesFromModel(this.marriageDocModel);
    this.onFormChanges();
  }

  setDocModel() {
    this.marriageDocModel.NID = new NID(this.docForm.get('NID').value);
    this.marriageDocModel.SpouseFullName = this.docForm.get('spouseFullName').value;
    this.marriageDocModel.RelationId = this.docForm.get('relationId').value;
    this.marriageDocModel.NumberOfCopies = this.docForm.get('numberOfCopies').value;
    this.marriageDocModel.Name = new RequesterNameModel();
    this.marriageDocModel.Name.FirstName = this.docForm.get('requesterName').get('firstName').value;
    this.marriageDocModel.Name.FatherName = this.docForm.get('requesterName').get('fatherName').value;
    this.marriageDocModel.Name.GrandFatherName = this.docForm.get('requesterName').get('grandFatherName').value;
    this.marriageDocModel.Name.FamilyName = this.docForm.get('requesterName').get('familyName').value;
    this.docTypeModel.doc = this.marriageDocModel;
    this.docTypeModel.isAgreed = this.docForm.get('agreement').value;
  }

  setFormValuesFromModel(marriageDocModel: MarriageDocModel) {
    this.docForm.patchValue({
      NID: marriageDocModel.NID ? marriageDocModel.NID.NationalIdenNumber : null,
      spouseFullName: marriageDocModel.SpouseFullName,
      relationId: marriageDocModel.RelationId,
      numberOfCopies: marriageDocModel.NumberOfCopies,
      agreement: this.docTypeModel.isAgreed,
      requesterName: {
        firstName: marriageDocModel.Name ? marriageDocModel.Name.FirstName : null,
        fatherName: marriageDocModel.Name ? marriageDocModel.Name.FatherName : null,
        grandFatherName: marriageDocModel.Name ? marriageDocModel.Name.GrandFatherName : null,
        familyName: marriageDocModel.Name ? marriageDocModel.Name.FamilyName : null
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
      relationId: new FormControl('', Validators.required),
      NID: new FormControl('', Validators.required),
      spouseFullName: new FormControl('', Validators.required),
      numberOfCopies: new FormControl('', Validators.required),
      agreement: new FormControl('')
    });
  }
}
