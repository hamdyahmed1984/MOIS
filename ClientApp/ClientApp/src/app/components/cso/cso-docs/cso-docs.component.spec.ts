import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsoDocsComponent } from './cso-docs.component';

describe('CsoDocsComponent', () => {
  let component: CsoDocsComponent;
  let fixture: ComponentFixture<CsoDocsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsoDocsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsoDocsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
