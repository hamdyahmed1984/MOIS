import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { LookupsService } from 'src/app/services/lookups.service';
import { DomSanitizer } from '@angular/platform-browser';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-cso-doc-base',
  templateUrl: './cso-doc-base.component.html',
  styleUrls: ['./cso-doc-base.component.css']
})
export class CsoDocBaseComponent implements OnInit {
  @Input() docTypeModel: any;
  @Output() notifyDocModelChanges: EventEmitter<any> = new EventEmitter<any>();

  regulations: any;
  gendersList: any;
  relationsList: any;
  numberOfCopiesList: any;
  jobTypesList: any;
  issueReasonsList: any;
  docForm: FormGroup;

  constructor(private lookupsService: LookupsService, private sanitizer: DomSanitizer) { }

  ngOnInit() {
  }

  getGendersList() {
    this.lookupsService.getGenders().subscribe(genders => { this.gendersList = genders; });
  }

  getRelationsList() {
    this.lookupsService.getRelations().subscribe(relations => { this.relationsList = relations; });
  }

  getJobTypesList() {
    this.lookupsService.getJobTypesForNid().subscribe(genders => { this.jobTypesList = genders; });
  }

  getIssueReasonsList() {
    this.lookupsService.getIssuingReasonsForNid().subscribe(relations => { this.issueReasonsList = relations; });
  }

  getDocRegulations(docTypeCode: string, jobTypeIdForNid?: number) {
    this.lookupsService.getRegulations().subscribe(regs => {
      // console.log(regs);
      this.regulations = jobTypeIdForNid ?
      this.sanitizer.bypassSecurityTrustHtml(regs.find( a =>
        a.DocTypeCode === docTypeCode && a.JobTypeNIDId ===  jobTypeIdForNid).Regulations)
      :
      this.sanitizer.bypassSecurityTrustHtml(regs.find( a => a.DocTypeCode === docTypeCode ).Regulations);
    });
  }

  onFormChanges(): void {
    this.docForm.valueChanges.subscribe(val => {
      this.setDocModel();
      this.notifyChanges();
    });
  }

  isValid() {
    return this.docForm.valid;
  }

  notifyChanges() {
    // console.log('notifying a change ...');
    // this.notifyDocModelChanges.emit({docTypeModel: this.docTypeModel, isValid: this.isValid()});
    // this.notifyDocModelChanges.emit(this.docTypeModel);
  }

  setDocModel() {}

  getNumberOfCopiesList() {
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

}
