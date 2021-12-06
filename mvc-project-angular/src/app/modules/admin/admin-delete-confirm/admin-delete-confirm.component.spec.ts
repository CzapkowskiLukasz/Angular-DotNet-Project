import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminDeleteConfirmComponent } from './admin-delete-confirm.component';

describe('AdminDeleteConfirmComponent', () => {
  let component: AdminDeleteConfirmComponent;
  let fixture: ComponentFixture<AdminDeleteConfirmComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminDeleteConfirmComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminDeleteConfirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
