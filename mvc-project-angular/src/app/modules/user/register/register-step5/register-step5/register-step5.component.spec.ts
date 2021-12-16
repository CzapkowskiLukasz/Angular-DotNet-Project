import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterStep5Component } from './register-step5.component';

describe('RegisterStep5Component', () => {
  let component: RegisterStep5Component;
  let fixture: ComponentFixture<RegisterStep5Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterStep5Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterStep5Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
