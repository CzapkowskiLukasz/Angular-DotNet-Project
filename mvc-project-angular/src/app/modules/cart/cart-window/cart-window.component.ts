import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/core/cart/cart.service';
import { CartItem } from 'src/app/shared/models/cart-item';

@Component({
  selector: 'app-cart-window',
  templateUrl: './cart-window.component.html',
  styleUrls: ['./cart-window.component.css']
})
export class CartWindowComponent implements OnInit {

  sum: number;

  products: CartItem[] = [];

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.getCart();
  }

  getCart() {
    this.cartService.getUserCart().subscribe(result => {
      this.products = result.products;
      this.sum = result.sum;
    });
  }
}
