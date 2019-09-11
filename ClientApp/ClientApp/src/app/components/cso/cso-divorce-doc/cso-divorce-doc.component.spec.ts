import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsoDivorceDocComponent } from './cso-divorce-doc.component';

describe('CsoDivorceDocComponent', () => {
  let component: CsoDivorceDocComponent;
  let fixture: ComponentFixture<CsoDivorceDocComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsoDivorceDocComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsoDivorceDocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
