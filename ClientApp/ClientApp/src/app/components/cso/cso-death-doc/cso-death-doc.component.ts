import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LookupsService } from 'src/app/services/lookups.service';
import { NID, RequesterNameModel } from 'src/app/models/RequestModel';
import { DeathDocModel } from 'src/app/models/Documents/DeathDocModel';
import { DomSanitizer } from '@angular/platform-browser';
import { CsoDocBaseComponent } from '../cso-doc-base/cso-doc-base.component';

@Component({
  selector: 'app-cso-death-doc',
  templateUrl: './cso-death-doc.component.html',
  styleUrls: ['./cso-death-doc.component.css']
})
export class CsoDeathDocComponent extends CsoDocBaseComponent implements OnInit {

  title = 'Death Doc';
  deathDocModel: DeathDocModel;
  docTypeCode = 'MOICSO005';

  constructor(lookupsService: LookupsService, sanitizer: DomSanitizer) {
    super(lookupsService, sanitizer);
    this.docForm = this.createFormGroup();
  }

  ngOnInit() {
    this.numberOfCopiesList = this.getNumberOfCopiesList();
    console.log(this.docTypeModel);
    this.deathDocModel = this.docTypeModel.doc;
    this.getGendersList();
    this.getRelationsList();
    this.getDocRegulations(this.docTypeCode);
    this.setFormValuesFromModel(this.deathDocModel);
    this.onFormChanges();
  }

  setDocModel() {
    this.deathDocModel.GenderId = this.docForm.get('genderId').value;
    this.deathDocModel.NID = new NID(this.docForm.get('NID').value);
    this.deathDocModel.MotherFullName = this.docForm.get('motherFullName').value;
    this.deathDocModel.RelationId = this.docForm.get('relationId').value;
    this.deathDocModel.NumberOfCopies = this.docForm.get('numberOfCopies').value;
    this.deathDocModel.Name = new RequesterNameModel();
    this.deathDocModel.Name.FirstName = this.docForm.get('requesterName').get('firstName').value;
    this.deathDocModel.Name.FatherName = this.docForm.get('requesterName').get('fatherName').value;
    this.deathDocModel.Name.GrandFatherName = this.docForm.get('requesterName').get('grandFatherName').value;
    this.deathDocModel.Name.FamilyName = this.docForm.get('requesterName').get('familyName').value;
    this.docTypeModel.doc = this.deathDocModel;
    this.docTypeModel.isAgreed = this.docForm.get('agreement').value;
  }

  setFormValuesFromModel(deathDocModel: DeathDocModel) {
    this.docForm.patchValue({
      genderId: deathDocModel.GenderId,
      NID: deathDocModel.NID ? deathDocModel.NID.NationalIdenNumber : null,
      motherFullName: deathDocModel.MotherFullName,
      relationId: deathDocModel.RelationId,
      numberOfCopies: deathDocModel.NumberOfCopies,
      agreement: this.docTypeModel.isAgreed,
      requesterName: {
        firstName: deathDocModel.Name ? deathDocModel.Name.FirstName : null,
        fatherName: deathDocModel.Name ? deathDocModel.Name.FatherName : null,
        grandFatherName: deathDocModel.Name ? deathDocModel.Name.GrandFatherName : null,
        familyName: deathDocModel.Name ? deathDocModel.Name.FamilyName : null
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
