import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { Observable } from 'rxjs';

import { RequestsService } from '../../services/requests.service';
import { RequestModel, RequesterNameModel, ContactDetailsModel, AddressModel, NID } from '../../models/RequestModel';
import { LookupsService } from './../../services/lookups.service';
import { forbiddenNameValidator } from './../../helpers/forbidden-name';
import { sameNameValidator } from './../../helpers/same-name';
import { CsrFormDataService } from './../../services/csr-form-data.service';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})
export class RequestsComponent implements OnInit {

  title = 'Requester personal data';
  requestModel: RequestModel;

  gendersList: any;
  selectedGender: number;
  //residencyAddressModel: AddressModel;
  //deliveryAddressModel: AddressModel;
  isLoading: boolean;

  requestForm: FormGroup;

  constructor(private requestsService: RequestsService,
    private lookupsService: LookupsService,
    private router: Router,
    private csrFormDataService: CsrFormDataService) {
    this.requestForm = this.createFormGroup();
  }

  ngOnInit() {
    this.requestModel = this.csrFormDataService.getRequestModel();
    this.getGendersList();
    this.setFormValuesFromModel(this.requestModel);
  }

  set(form: any): boolean {
    if (!form.valid)
      return false;

    this.getRequestModelFromFormValues();
    this.csrFormDataService.setRequestModel(this.requestModel);
    return true;
  }

  goNext(form: any) {
    if (this.set(form))
      this.router.navigate(['/csr/address']);
  }

  getGendersList() {
    //return [{ "Id": 1, "Name": "Male" },
    //{ "Id": 2, "Name": "Female" }];
    this.lookupsService.getGenders().subscribe(genders => { this.gendersList = genders; console.log(this.gendersList); });
  }

  selectGender() {
    console.log("Selected gender: " + this.requestForm.get('genderId').value);
  }

  createRequest() {
    this.isLoading = true;
    this.getRequestModelFromFormValues();
    this.requestsService.createRequest(this.requestModel)
      .subscribe(result => {
        console.log(result);
        this.isLoading = false;
      });
  }


  private createFormGroup() {
    return new FormGroup({
      genderId: new FormControl('', Validators.required),
      NID: new FormControl(''),
      motherFullName: new FormControl(''),
      issuerId: new FormControl(''),
      paymentMethodId: new FormControl(''),
      requesterName: new FormGroup({
        firstName: new FormControl('', [Validators.required, Validators.maxLength(20), forbiddenNameValidator(/bob/i) // <-- Here's how you pass in the custom validator.
        ]),
        fatherName: new FormControl('', [Validators.required, Validators.maxLength(20)]),
        grandFatherName: new FormControl('', [Validators.required, Validators.maxLength(20)]),
        familyName: new FormControl('', [Validators.required, Validators.maxLength(20)])
      }, { validators: sameNameValidator }),
      contactDetails: new FormGroup({
        email: new FormControl(''),
        phoneHome: new FormControl(''),
        phoneWork: new FormControl(''),
        mobile1: new FormControl(''),
        mobile2: new FormControl('')
      })
    });
  }

  private getRequestModelFromFormValues(): RequestModel {
    //requestModel.Id = requestForm.value.Id;
    this.requestModel.GenderId = this.requestForm.get('genderId').value;
    this.requestModel.NID = new NID(this.requestForm.get('NID').value);
    this.requestModel.MotherFullName = this.requestForm.get('motherFullName').value;
    this.requestModel.PaymentMethodId = 2;//Consider changing this
    this.requestModel.IssuerId = 1;//Consider changing this

    this.requestModel.Name = this.getRequesterNameFromFormValues();
    this.requestModel.ContactDetails = this.getContactDetailsFromFormValues();
    //this.requestModel.ResidencyAddress = this.residencyAddressModel;
    //this.requestModel.DeliveryAddress = this.requestForm.get('residencyAddressSameAsDeliveryAddress').value ?
    //  this.requestModel.ResidencyAddress : this.deliveryAddressModel;
    console.log(this.requestModel);
    return this.requestModel;
  }
  private getRequesterNameFromFormValues(): RequesterNameModel {
    let requesterNameModel = new RequesterNameModel();

    requesterNameModel.FirstName = this.requestForm.get('requesterName.firstName').value;
    requesterNameModel.FatherName = this.requestForm.get('requesterName.fatherName').value;
    requesterNameModel.GrandFatherName = this.requestForm.get('requesterName.grandFatherName').value;
    requesterNameModel.FamilyName = this.requestForm.get('requesterName.familyName').value;

    return requesterNameModel;
  }
  private getContactDetailsFromFormValues(): ContactDetailsModel {
    let contactDetailsModel = new ContactDetailsModel();

    contactDetailsModel.Email = this.requestForm.get('contactDetails.email').value;
    contactDetailsModel.PhoneHome = this.requestForm.get('contactDetails.phoneHome').value;
    contactDetailsModel.PhoneWork = this.requestForm.get('contactDetails.phoneWork').value;
    contactDetailsModel.Mobile1 = this.requestForm.get('contactDetails.mobile1').value;
    contactDetailsModel.Mobile2 = this.requestForm.get('contactDetails.mobile2').value;

    return contactDetailsModel;
  }

  private setFormValuesFromModel(requestModel: RequestModel) {
    this.requestForm.patchValue({
      genderId: requestModel.GenderId,
      NID: requestModel.NID ? requestModel.NID.NationalIdenNumber : null,
      motherFullName: requestModel.MotherFullName,
      issuerId: requestModel.IssuerId,
      paymentMethodId: requestModel.PaymentMethodId,
      requesterName: {
        firstName: requestModel.Name ? requestModel.Name.FirstName : null,
        fatherName: requestModel.Name ? requestModel.Name.FatherName : null,
        grandFatherName: requestModel.Name ? requestModel.Name.GrandFatherName : null,
        familyName: requestModel.Name ? requestModel.Name.FamilyName : null
      },
      contactDetails: {
        email: requestModel.ContactDetails ? requestModel.ContactDetails.Email : null,
        phoneHome: requestModel.ContactDetails ? requestModel.ContactDetails.PhoneHome : null,
        phoneWork: requestModel.ContactDetails ? requestModel.ContactDetails.PhoneWork : null,
        mobile1: requestModel.ContactDetails ? requestModel.ContactDetails.Mobile1 : null,
        mobile2: requestModel.ContactDetails ? requestModel.ContactDetails.Mobile2 : null
      }
    });
  }

}
