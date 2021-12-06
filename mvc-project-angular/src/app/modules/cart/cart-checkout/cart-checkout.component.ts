import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-cart-checkout',
  templateUrl: './cart-checkout.component.html',
  styleUrls: ['./cart-checkout.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CartCheckoutComponent implements OnInit {

  addAddress: boolean;
  constructor() {
    this.addAddress = false;
  }

  ngOnInit(): void {
  }

  showAddAddress() {
    this.addAddress = true
  }

  hideAddAddress() {
    this.addAddress = false;
  }
}
