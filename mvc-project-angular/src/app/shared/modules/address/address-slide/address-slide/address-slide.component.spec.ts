import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressSlideComponent } from './address-slide.component';

describe('AddressSlideComponent', () => {
  let component: AddressSlideComponent;
  let fixture: ComponentFixture<AddressSlideComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddressSlideComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddressSlideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
