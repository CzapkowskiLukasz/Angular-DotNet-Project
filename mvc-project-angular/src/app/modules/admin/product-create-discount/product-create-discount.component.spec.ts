import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductCreateDiscountComponent } from './product-create-discount.component';

describe('ProductCreateDiscountComponent', () => {
  let component: ProductCreateDiscountComponent;
  let fixture: ComponentFixture<ProductCreateDiscountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductCreateDiscountComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductCreateDiscountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
