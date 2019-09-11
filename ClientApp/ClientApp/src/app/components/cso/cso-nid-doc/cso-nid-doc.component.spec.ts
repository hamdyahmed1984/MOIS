import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsoNidDocComponent } from './cso-nid-doc.component';

describe('CsoNidDocComponent', () => {
  let component: CsoNidDocComponent;
  let fixture: ComponentFixture<CsoNidDocComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsoNidDocComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsoNidDocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
