import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BirthDocModel } from 'src/app/models/Documents/BirthDocModel';
import { LookupsService } from 'src/app/services/lookups.service';
import { NID, RequesterNameModel } from 'src/app/models/RequestModel';
import { DomSanitizer } from '@angular/platform-browser';
import { CsoDocBaseComponent } from '../cso-doc-base/cso-doc-base.component';

@Component({
  selector: 'app-cso-birth-doc',
  templateUrl: './cso-birth-doc.component.html',
  styleUrls: ['./cso-birth-doc.component.css']
})
export class CsoBirthDocComponent extends CsoDocBaseComponent implements OnInit {

  title = 'Birth Doc';
  birthDocModel: BirthDocModel;
  docTypeCode = 'MOICSO001';

  constructor(lookupsService: LookupsService, sanitizer: DomSanitizer) {
    super(lookupsService, sanitizer);
    this.docForm = this.createFormGroup();
  }

  ngOnInit() {
    this.numberOfCopiesList = this.getNumberOfCopiesList();
    console.log(this.docTypeModel);
    this.birthDocModel = this.docTypeModel.doc;
    this.getGendersList();
    this.getRelationsList();
    this.getDocRegulations(this.docTypeCode);
    this.setFormValuesFromModel(this.birthDocModel);
    this.onFormChanges();
  }

  setDocModel() {
    this.birthDocModel.GenderId = this.docForm.get('genderId').value;
    this.birthDocModel.NID = new NID(this.docForm.get('NID').value);
    this.birthDocModel.MotherFullName = this.docForm.get('motherFullName').value;
    this.birthDocModel.RelationId = this.docForm.get('relationId').value;
    this.birthDocModel.NumberOfCopies = this.docForm.get('numberOfCopies').value;
    this.birthDocModel.IsFirstTime = this.docForm.get('isFirstTime').value;
    this.birthDocModel.Name = new RequesterNameModel();
    this.birthDocModel.Name.FirstName = this.docForm.get('requesterName').get('firstName').value;
    this.birthDocModel.Name.FatherName = this.docForm.get('requesterName').get('fatherName').value;
    this.birthDocModel.Name.GrandFatherName = this.docForm.get('requesterName').get('grandFatherName').value;
    this.birthDocModel.Name.FamilyName = this.docForm.get('requesterName').get('familyName').value;
    this.docTypeModel.doc = this.birthDocModel;
    this.docTypeModel.isAgreed = this.docForm.get('agreement').value;
  }

  setFormValuesFromModel(birthDocModel: BirthDocModel) {
    this.docForm.patchValue({
      genderId: birthDocModel.GenderId,
      NID: birthDocModel.NID ? birthDocModel.NID.NationalIdenNumber : null,
      motherFullName: birthDocModel.MotherFullName,
      relationId: birthDocModel.RelationId,
      numberOfCopies: birthDocModel.NumberOfCopies,
      isFirstTime: birthDocModel.IsFirstTime,
      agreement: this.docTypeModel.isAgreed,
      requesterName: {
        firstName: birthDocModel.Name ? birthDocModel.Name.FirstName : null,
        fatherName: birthDocModel.Name ? birthDocModel.Name.FatherName : null,
        grandFatherName: birthDocModel.Name ? birthDocModel.Name.GrandFatherName : null,
        familyName: birthDocModel.Name ? birthDocModel.Name.FamilyName : null
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
      genderId: new FormControl('', Validators.required),
      relationId: new FormControl('', Validators.required),
      NID: new FormControl('', Validators.required),
      motherFullName: new FormControl('', Validators.required),
      numberOfCopies: new FormControl('', Validators.required),
      isFirstTime: new FormControl(''),
      agreement: new FormControl('')
    });
  }
}
