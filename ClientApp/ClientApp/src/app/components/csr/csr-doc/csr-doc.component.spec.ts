import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsrDocComponent } from './csr-doc.component';

describe('CsrDocComponent', () => {
  let component: CsrDocComponent;
  let fixture: ComponentFixture<CsrDocComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsrDocComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsrDocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
