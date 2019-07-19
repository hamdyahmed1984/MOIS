import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsrHomeComponent } from './csr-home.component';

describe('CsrHomeComponent', () => {
  let component: CsrHomeComponent;
  let fixture: ComponentFixture<CsrHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsrHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsrHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
