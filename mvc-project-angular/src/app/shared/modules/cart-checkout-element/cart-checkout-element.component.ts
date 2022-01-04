import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductService } from 'src/app/core/product/product.service';

@Component({
  selector: 'app-cart-checkout-element',
  templateUrl: './cart-checkout-element.component.html',
  styleUrls: ['./cart-checkout-element.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CartCheckoutElementComponent implements OnInit {

  @Input() product;

  constructor(){}

  ngOnInit(): void {
  }

}
