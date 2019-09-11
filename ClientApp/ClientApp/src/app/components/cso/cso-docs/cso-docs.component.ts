import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CsoFormDataService } from 'src/app/services/cso-form-data.service';
import { of } from 'rxjs';
import { DocTypesModel } from 'src/app/models/Documents/DocTypesModel';
import { BirthDocModel } from 'src/app/models/Documents/BirthDocModel';
import { DeathDocModel } from 'src/app/models/Documents/DeathDocModel';
import { MarriageDocModel } from 'src/app/models/Documents/MarriageDocModel';
import { DivorceDocModel } from 'src/app/models/Documents/DivorceDocModel';
import { NidDocModel } from 'src/app/models/Documents/NidDocModel';
import { DocTypeEnum } from 'src/app/models/Documents/DocTypeEnum';
import { DocTypeFactory } from 'src/app/models/Documents/DocTypeFactory';

@Component({
  selector: 'app-cso-docs',
  templateUrl: './cso-docs.component.html',
  styleUrls: ['./cso-docs.component.css']
})
export class CsoDocsComponent implements OnInit {

  title = 'Docs Outline';
  docTypesModel: DocTypesModel;
  docTypesForm: FormGroup;
  docsCountsList: any;

  constructor(private router: Router,
    private csoFormDataService: CsoFormDataService) {
    this.docTypesForm = this.createFormGroup();
    // async list of docs counts
    of(this.getDocsCountList()).subscribe(docsCounts => {
      this.docsCountsList = docsCounts;
    });
  }

  ngOnInit() {
    this.docTypesModel = this.csoFormDataService.getDocTypesModel();
    this.setFormValuesFromModel(this.docTypesModel);
    this.onFormChanges();
  }

  onFormChanges(): void {
    this.docTypesForm.valueChanges.subscribe(val => {
      this.isValid();
    });
  }

  createFormGroup(): FormGroup {
    return new FormGroup({
      // BirthDocsCount: new FormControl('', Validators.required),
      birthDocsCount: new FormControl(''),
      deathDocsCount: new FormControl(''),
      marriageDocsCount: new FormControl(''),
      divorceDocsCount: new FormControl(''),
      nidDocsCount: new FormControl('')
    });
  }

  getDocsCountList() {
    return [
      { id: '', value: '' },
      { id: '1', value: '1' },
      { id: '2', value: '2' },
      { id: '3', value: '3' },
      { id: '4', value: '4' },
      { id: '5', value: '5' },
      { id: '6', value: '6' },
      { id: '7', value: '7' },
      { id: '8', value: '8' },
      { id: '9', value: '9' },
      { id: '10', value: '10' },
    ];
  }

  goPrevious() {
    this.router.navigate(['/csr/address']);
  }

  goNext() {
    if (this.set()) {
      this.router.navigate(['/cso/docs-details']);
    }
  }

  set(): boolean {
    if (!this.isValid()) {
      return false;
    }

    this.setDocTypesModel();
    this.csoFormDataService.setDocTypesModel(this.docTypesModel);
    return true;
  }


  isValid(): boolean {
    return this.docTypesForm.get('birthDocsCount').value > 0 ||
      this.docTypesForm.get('deathDocsCount').value > 0 ||
      this.docTypesForm.get('marriageDocsCount').value > 0 ||
      this.docTypesForm.get('nidDocsCount').value > 0 ||
      this.docTypesForm.get('divorceDocsCount').value > 0;
  }

  private setDocTypesModel(): DocTypesModel {
    this.setBirthDocsModel();
    this.setDeathDocsModel();
    this.setMarriageDocsModel();
    this.setDivorceDocsModel();
    this.setNidDocsModel();
    return this.docTypesModel;
  }

  private setBirthDocsModel() {
    const newCount = this.docTypesForm.get('birthDocsCount').value || 0;
    this.docTypesModel.adjustDocsCountOfType(DocTypeEnum.BirthDoc, newCount);
  }

  private setDeathDocsModel() {
    const newCount = this.docTypesForm.get('deathDocsCount').value || 0;
    this.docTypesModel.adjustDocsCountOfType(DocTypeEnum.DeathDoc, newCount);
  }

  private setMarriageDocsModel() {
    const newCount = this.docTypesForm.get('marriageDocsCount').value || 0;
    this.docTypesModel.adjustDocsCountOfType(DocTypeEnum.MarriageDoc, newCount);
  }

  private setDivorceDocsModel() {
    const newCount = this.docTypesForm.get('divorceDocsCount').value || 0;
    this.docTypesModel.adjustDocsCountOfType(DocTypeEnum.DivorceDoc, newCount);
  }

  private setNidDocsModel() {
    const newCount = this.docTypesForm.get('nidDocsCount').value || 0;
    this.docTypesModel.adjustDocsCountOfType(DocTypeEnum.NidDoc, newCount);
  }

  private setFormValuesFromModel(docTypesModel: DocTypesModel) {
    this.docTypesForm.patchValue({
      birthDocsCount: docTypesModel.getDocsCountOfType(DocTypeEnum.BirthDoc),
      deathDocsCount: docTypesModel.getDocsCountOfType(DocTypeEnum.DeathDoc),
      marriageDocsCount: docTypesModel.getDocsCountOfType(DocTypeEnum.MarriageDoc),
      divorceDocsCount: docTypesModel.getDocsCountOfType(DocTypeEnum.DivorceDoc),
      nidDocsCount: docTypesModel.getDocsCountOfType(DocTypeEnum.NidDoc)
    });
  }
}

