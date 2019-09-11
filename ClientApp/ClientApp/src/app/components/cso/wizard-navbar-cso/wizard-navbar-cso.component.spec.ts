import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WizardNavbarCsoComponent } from './wizard-navbar-cso.component';

describe('WizardNavbarCsoComponent', () => {
  let component: WizardNavbarCsoComponent;
  let fixture: ComponentFixture<WizardNavbarCsoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WizardNavbarCsoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WizardNavbarCsoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
