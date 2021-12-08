import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpandFormComponent } from './expand-form.component';

describe('ExpandFormComponent', () => {
  let component: ExpandFormComponent;
  let fixture: ComponentFixture<ExpandFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExpandFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExpandFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
