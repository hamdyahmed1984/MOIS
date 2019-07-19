import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WizardNavbarCsrComponent } from './wizard-navbar-csr.component';

describe('WizardNavbarCsrComponent', () => {
  let component: WizardNavbarCsrComponent;
  let fixture: ComponentFixture<WizardNavbarCsrComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WizardNavbarCsrComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WizardNavbarCsrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
