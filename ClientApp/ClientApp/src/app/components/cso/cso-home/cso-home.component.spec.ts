import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsoHomeComponent } from './cso-home.component';

describe('CsoHomeComponent', () => {
  let component: CsoHomeComponent;
  let fixture: ComponentFixture<CsoHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsoHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsoHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
