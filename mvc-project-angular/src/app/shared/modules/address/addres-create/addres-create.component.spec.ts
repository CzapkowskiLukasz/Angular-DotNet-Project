import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddresCreateComponent } from './addres-create.component';

describe('AddresCreateComponent', () => {
  let component: AddresCreateComponent;
  let fixture: ComponentFixture<AddresCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddresCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddresCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
