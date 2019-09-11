import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LookupsService } from 'src/app/services/lookups.service';
import { NID, RequesterNameModel } from 'src/app/models/RequestModel';
import { DivorceDocModel } from 'src/app/models/Documents/DivorceDocModel';
import { DomSanitizer } from '@angular/platform-browser';
import { CsoDocBaseComponent } from '../cso-doc-base/cso-doc-base.component';

@Component({
  selector: 'app-cso-divorce-doc',
  templateUrl: './cso-divorce-doc.component.html',
  styleUrls: ['./cso-divorce-doc.component.css']
})
export class CsoDivorceDocComponent extends CsoDocBaseComponent implements OnInit {

  title = 'Divorce Doc';
  divorceDocModel: DivorceDocModel;
  docTypeCode = 'MOICSO004';

  constructor(lookupsService: LookupsService, sanitizer: DomSanitizer) {
    super(lookupsService, sanitizer);
    this.docForm = this.createFormGroup();
  }

  ngOnInit() {
    this.numberOfCopiesList = this.getNumberOfCopiesList();
    console.log(this.docTypeModel);
    this.divorceDocModel = this.docTypeModel.doc;
    this.getRelationsList();
    this.getDocRegulations(this.docTypeCode);
    this.setFormValuesFromModel(this.divorceDocModel);
    this.onFormChanges();
  }

  setDocModel() {
    this.divorceDocModel.NID = new NID(this.docForm.get('NID').value);
    this.divorceDocModel.SpouseFullName = this.docForm.get('spouseFullName').value;
    this.divorceDocModel.RelationId = this.docForm.get('relationId').value;
    this.divorceDocModel.NumberOfCopies = this.docForm.get('numberOfCopies').value;
    this.divorceDocModel.Name = new RequesterNameModel();
    this.divorceDocModel.Name.FirstName = this.docForm.get('requesterName').get('firstName').value;
    this.divorceDocModel.Name.FatherName = this.docForm.get('requesterName').get('fatherName').value;
    this.divorceDocModel.Name.GrandFatherName = this.docForm.get('requesterName').get('grandFatherName').value;
    this.divorceDocModel.Name.FamilyName = this.docForm.get('requesterName').get('familyName').value;
    this.docTypeModel.doc = this.divorceDocModel;
    this.docTypeModel.isAgreed = this.docForm.get('agreement').value;
  }

  setFormValuesFromModel(divorceDocModel: DivorceDocModel) {
    this.docForm.patchValue({
      NID: divorceDocModel.NID ? divorceDocModel.NID.NationalIdenNumber : null,
      spouseFullName: divorceDocModel.SpouseFullName,
      relationId: divorceDocModel.RelationId,
      numberOfCopies: divorceDocModel.NumberOfCopies,
      agreement: this.docTypeModel.isAgreed,
      requesterName: {
        firstName: divorceDocModel.Name ? divorceDocModel.Name.FirstName : null,
        fatherName: divorceDocModel.Name ? divorceDocModel.Name.FatherName : null,
        grandFatherName: divorceDocModel.Name ? divorceDocModel.Name.GrandFatherName : null,
        familyName: divorceDocModel.Name ? divorceDocModel.Name.FamilyName : null
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
