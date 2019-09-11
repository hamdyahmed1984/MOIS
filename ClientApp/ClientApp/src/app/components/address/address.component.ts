import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { LookupsService } from 'src/app/services/lookups.service';
import { AddressModel } from 'src/app/models/RequestModel';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit {

  govsList: any;
  policeDeptsList: any;
  postalCodesList: any;
  @Output() notify: EventEmitter<any> = new EventEmitter<any>();

  addressForm: FormGroup;


  constructor(private lookupsService: LookupsService) {
    this.getGovsList();
    // this.getPoliceDeptsList();
    // this.getPostalCodesList();
    this.addressForm = this.createAddressForm();
  }

  ngOnInit() {
  }

  getGovsList() {
    this.lookupsService.getGovernorates().subscribe(govs => {
      this.govsList = govs;
      // console.log('Governorates:');
      // console.log(this.govsList);
    });
  }

  getPoliceDeptsList() {
    this.lookupsService.getPoliceDepartments().subscribe(policeDepts => {
      this.policeDeptsList = policeDepts.filter(a => a.Governorate.Id === this.addressForm.get('governorateId').value);
    });
  }

  getPostalCodesList() {
    this.lookupsService.getPostalCodes().subscribe(postalCodes => {
      this.postalCodesList = postalCodes.filter(a => a.Governorate.Id === this.addressForm.get('governorateId').value);
    });
  }

  selectGov() {
    // console.log('Selected Gov: ' + this.addressForm.get('policeDepartmentId').value);
    this.getPoliceDeptsList();
    this.getPostalCodesList();
    this.notifyAddressPropChange();
  }

  selectPoliceDept() {
    // console.log('Selected Police Department: ' + this.addressForm.get('policeDepartmentId').value);
    this.notifyAddressPropChange();
  }

  selectPostalCode() {
    // console.log('Selected Postal Office: ' + this.addressForm.get('postalCodeId').value);
    this.notifyAddressPropChange();
  }

  notifyAddressPropChange() {
    const addressModel: AddressModel = new AddressModel();
    addressModel.FlatNumber = this.addressForm.get('flatNumber').value;
    addressModel.FloorNumber = this.addressForm.get('floorNumber').value;
    addressModel.BuildingNumber = this.addressForm.get('buildingNumber').value;
    addressModel.StreetName = this.addressForm.get('streetName').value;
    addressModel.DistrictName = this.addressForm.get('districtName').value;
    addressModel.GovernorateId = this.addressForm.get('governorateId').value;
    addressModel.PoliceDepartmentId = this.addressForm.get('policeDepartmentId').value;
    addressModel.PostalCodeId = this.addressForm.get('postalCodeId').value;
    this.notify.emit({ addressModel: addressModel, isFormValid: this.addressForm.valid });
  }

  private createAddressForm() {
    return new FormGroup({
      flatNumber: new FormControl('', Validators.required),
      floorNumber: new FormControl('', Validators.required),
      buildingNumber: new FormControl(''),
      streetName: new FormControl(''),
      districtName: new FormControl(''),
      governorateId: new FormControl(''),
      policeDepartmentId: new FormControl(''),
      postalCodeId: new FormControl('')
    });
  }

  setFormValuesFromModel(addressModel: AddressModel) {
    this.addressForm.patchValue({
      flatNumber: addressModel.FlatNumber,
      floorNumber: addressModel.FloorNumber,
      buildingNumber: addressModel.BuildingNumber,
      streetName: addressModel.StreetName,
      districtName: addressModel.DistrictName,
      governorateId: addressModel.GovernorateId,
      policeDepartmentId: addressModel.PoliceDepartmentId,
      postalCodeId: addressModel.PostalCodeId
    });
    // Notify the change to make the parent components catch the valid state of the form
    this.notifyAddressPropChange();
  }

}
