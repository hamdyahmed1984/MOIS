import { Component, OnInit } from '@angular/core';
import { RequestModel, AddressGroupModel } from './../../../models/RequestModel';
import { CriminalStateRecordModel } from './../../../models/Documents/CriminalStateRecordModel';
import { Router } from '@angular/router';
import { CsrFormDataService } from './../../../services/csr-form-data.service';
import { RequestsService } from './../../../services/requests.service';

@Component({
  selector: 'app-csr-confirm',
  templateUrl: './csr-confirm.component.html',
  styleUrls: ['./csr-confirm.component.css']
})
export class CsrConfirmComponent implements OnInit {

  title = 'Confirmation';

  requestModel: RequestModel;
  addressGroupModel: AddressGroupModel;
  csrDocModel: CriminalStateRecordModel;

  constructor(private router: Router, private csrFormDataService: CsrFormDataService, private requestsService: RequestsService) { }

  ngOnInit() {
    this.requestModel = this.csrFormDataService.getRequestModel();
    this.addressGroupModel = this.csrFormDataService.getAddressGroupModelModel();
    this.csrDocModel = this.csrFormDataService.getCsrDocModel();
  }

  goNext() {
    this.requestModel.ResidencyAddress = this.addressGroupModel.ResidencyAddress;
    this.requestModel.DeliveryAddress = this.addressGroupModel.DeliveryAddress;
    this.requestsService.createRequest(this.requestModel).subscribe(req => {
      console.log('Save CSR request is: ');
      console.log(req);
      console.log('Trying to create csr doc...');
      this.csrDocModel.RequestId = req.Id;
      this.requestsService.createCsrDoc(this.csrDocModel).subscribe(csrDoc => {
        console.log("Created Csr Doc:");
        console.log(csrDoc);
      });
    });

    alert('submitted!');
  }

  goPrevious() {
    //if (this.set(form))
    this.router.navigate(['/csr/doc']);
  }

}
