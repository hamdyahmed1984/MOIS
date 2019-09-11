import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsoDocsDetailsComponent } from './cso-docs-details.component';

describe('CsoDocsDetailsComponent', () => {
  let component: CsoDocsDetailsComponent;
  let fixture: ComponentFixture<CsoDocsDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsoDocsDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsoDocsDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
