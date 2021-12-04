import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartCheckoutElementComponent } from './cart-checkout-element.component';

describe('CartCheckoutElementComponent', () => {
  let component: CartCheckoutElementComponent;
  let fixture: ComponentFixture<CartCheckoutElementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartCheckoutElementComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CartCheckoutElementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
