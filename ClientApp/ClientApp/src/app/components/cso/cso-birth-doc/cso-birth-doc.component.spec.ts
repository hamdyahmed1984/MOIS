import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsoBirthDocComponent } from './cso-birth-doc.component';

describe('CsoBirthDocComponent', () => {
  let component: CsoBirthDocComponent;
  let fixture: ComponentFixture<CsoBirthDocComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsoBirthDocComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsoBirthDocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
