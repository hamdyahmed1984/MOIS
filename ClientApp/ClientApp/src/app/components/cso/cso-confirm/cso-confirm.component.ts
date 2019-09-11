import { Component, OnInit } from '@angular/core';
import { DocTypesModel } from 'src/app/models/Documents/DocTypesModel';
import { CsoFormDataService } from 'src/app/services/cso-form-data.service';
import { DocTypeFactory } from 'src/app/models/Documents/DocTypeFactory';
import { DocTypeEnum } from 'src/app/models/Documents/DocTypeEnum';
import { RequestModel, AddressGroupModel } from 'src/app/models/RequestModel';

@Component({
  selector: 'app-cso-confirm',
  templateUrl: './cso-confirm.component.html',
  styleUrls: ['./cso-confirm.component.css']
})
export class CsoConfirmComponent implements OnInit {

  docTypesModel: DocTypesModel;
  requestModel: RequestModel;
  addressGroupModel: AddressGroupModel;
  docTypeFactory: DocTypeFactory;

  constructor(private csoFormDataService: CsoFormDataService) {
    this.docTypesModel = csoFormDataService.getDocTypesModel();
    this.requestModel = csoFormDataService.getRequestModel();
    this.addressGroupModel = csoFormDataService.getAddressGroupModelModel();
    this.docTypeFactory = new DocTypeFactory();
  }

  ngOnInit() {
  }

  getDocName(docTypeEnum: DocTypeEnum) {
    return this.docTypeFactory.getDocName(docTypeEnum);
  }

}
