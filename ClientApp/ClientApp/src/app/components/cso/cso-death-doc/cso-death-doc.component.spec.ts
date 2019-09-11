import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsoDeathDocComponent } from './cso-death-doc.component';

describe('CsoDeathDocComponent', () => {
  let component: CsoDeathDocComponent;
  let fixture: ComponentFixture<CsoDeathDocComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsoDeathDocComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsoDeathDocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
