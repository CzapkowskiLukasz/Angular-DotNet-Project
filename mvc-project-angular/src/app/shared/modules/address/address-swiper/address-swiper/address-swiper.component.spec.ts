import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressSwiperComponent } from './address-swiper.component';

describe('AddressSwiperComponent', () => {
  let component: AddressSwiperComponent;
  let fixture: ComponentFixture<AddressSwiperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddressSwiperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddressSwiperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
