import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsrConfirmComponent } from './csr-confirm.component';

describe('CsrConfirmComponent', () => {
  let component: CsrConfirmComponent;
  let fixture: ComponentFixture<CsrConfirmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsrConfirmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsrConfirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
