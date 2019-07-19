import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressGroupComponent } from './address-group.component';

describe('AddressGroupComponent', () => {
  let component: AddressGroupComponent;
  let fixture: ComponentFixture<AddressGroupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddressGroupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddressGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
