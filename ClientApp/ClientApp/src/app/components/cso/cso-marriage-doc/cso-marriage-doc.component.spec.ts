import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsoMarriageDocComponent } from './cso-marriage-doc.component';

describe('CsoMarriageDocComponent', () => {
  let component: CsoMarriageDocComponent;
  let fixture: ComponentFixture<CsoMarriageDocComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsoMarriageDocComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsoMarriageDocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
