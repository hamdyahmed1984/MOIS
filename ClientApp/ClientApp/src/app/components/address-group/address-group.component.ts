import { Component, OnInit, ViewChildren, QueryList, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { FormControl } from '@angular/forms';
import { AddressModel, AddressGroupModel, } from '../../models/RequestModel';
import { Router } from '@angular/router';
import { CsrFormDataService } from './../../services/csr-form-data.service';
import { AddressComponent } from '../address/address.component';

@Component({
  selector: 'app-address-group',
  templateUrl: './address-group.component.html',
  styleUrls: ['./address-group.component.css']
})
export class AddressGroupComponent implements OnInit, AfterViewInit {
  @ViewChildren("residencyAddressView") residencyAddressViews: QueryList<any>;
  @ViewChildren("deliveryAddressView") deliveryAddressViews: QueryList<any>;

  residencyAddressSameAsDeliveryAddress = new FormControl(true);
  //residencyAddressModel: AddressModel;
  //deliveryAddressModel: AddressModel;
  residencyAddressFormValid: boolean;
  deliveryAddressFromValid: boolean;
  addressGroupModel: AddressGroupModel;

  title = 'Address details';

  constructor(private router: Router,
    private csrFormDataService: CsrFormDataService,
    private changeDetectRef: ChangeDetectorRef) { }

  ngOnInit() {
    this.addressGroupModel = this.csrFormDataService.getAddressGroupModelModel();
    this.residencyAddressSameAsDeliveryAddress.setValue(this.addressGroupModel.ResidencyAddressSameAsDeliveryAddress);
  }

  ngAfterViewInit(): void {

    if (!this.addressGroupModel.ResidencyAddress)
      return;

    let residencyAddressViewsArr: any[] = this.residencyAddressViews.toArray();
    if (residencyAddressViewsArr.length > 0)
      residencyAddressViewsArr[0].setFormValuesFromModel(this.addressGroupModel.ResidencyAddress);

    let deliveryAddressViewsArr: any[] = this.deliveryAddressViews.toArray();
    if (deliveryAddressViewsArr.length > 0)
      deliveryAddressViewsArr[0].setFormValuesFromModel(this.residencyAddressSameAsDeliveryAddress.value ?
        this.addressGroupModel.ResidencyAddress : this.addressGroupModel.DeliveryAddress);
    //This line is important to avoid the exception thrown by Angular when you try to change a variable in AfterViewInit
    //In our case the variable is change in setFormValuesFromModel
    this.changeDetectRef.detectChanges();
  }

  set(): boolean {
    if (!this.isResidencyAddressFormValid() || !this.isResidencyAddressFormValid())
      return false;

    this.addressGroupModel.ResidencyAddressSameAsDeliveryAddress = this.residencyAddressSameAsDeliveryAddress.value;
    if (this.addressGroupModel.ResidencyAddressSameAsDeliveryAddress)
      this.addressGroupModel.DeliveryAddress = this.addressGroupModel.ResidencyAddress;
    this.csrFormDataService.setAddressGroupModel(this.addressGroupModel);
    return true;
  }

  goPrevious() {
    //if (this.set(form))
    this.router.navigate(['/csr/requester']);
  }

  goNext() {
    if (this.set())
      this.router.navigate(['/csr/doc']);
  }

  onNotifyResidencyAddressPropChange(addressModelAndFormValidity: any) {
    this.addressGroupModel.ResidencyAddress = addressModelAndFormValidity.addressModel;
    this.residencyAddressFormValid = addressModelAndFormValidity.isFormValid;
    console.warn(this.addressGroupModel.ResidencyAddress);
    console.warn('Residency Address Form Is Valid? ' + this.residencyAddressFormValid);
  }

  onNotifyDeliveryAddressPropChange(addressModelAndFormValidity: any) {
    this.addressGroupModel.DeliveryAddress = addressModelAndFormValidity.addressModel;
    this.deliveryAddressFromValid = addressModelAndFormValidity.isFormValid;
    console.warn(this.addressGroupModel.DeliveryAddress);
    console.warn('Delivery Address Form Is Valid? ' + this.deliveryAddressFromValid);
  }

  isResidencyAddressFormValid(): boolean {
    return this.residencyAddressFormValid;
  }

  isDeliveryAddressFormValid(): boolean {
    return this.residencyAddressSameAsDeliveryAddress.value ? true : this.deliveryAddressFromValid;
  }

  isAddressGroupModelValid(): boolean {
    return this.isResidencyAddressFormValid() && this.isDeliveryAddressFormValid();
  }
}
