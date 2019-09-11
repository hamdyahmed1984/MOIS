import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsoDocBaseComponent } from './cso-doc-base.component';

describe('CsoDocBaseComponent', () => {
  let component: CsoDocBaseComponent;
  let fixture: ComponentFixture<CsoDocBaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsoDocBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsoDocBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
