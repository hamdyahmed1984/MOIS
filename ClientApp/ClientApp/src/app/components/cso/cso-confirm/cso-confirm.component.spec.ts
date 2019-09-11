import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsoConfirmComponent } from './cso-confirm.component';

describe('CsoConfirmComponent', () => {
  let component: CsoConfirmComponent;
  let fixture: ComponentFixture<CsoConfirmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsoConfirmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsoConfirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
