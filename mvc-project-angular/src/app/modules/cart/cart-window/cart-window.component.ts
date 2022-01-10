import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CartService } from 'src/app/core/cart/cart.service';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { CartItem } from 'src/app/shared/models/cart-item';

@Component({
  selector: 'app-cart-window',
  templateUrl: './cart-window.component.html',
  styleUrls: ['./cart-window.component.css']
})
export class CartWindowComponent implements OnInit, OnDestroy {

  sum: number;

  products: CartItem[] = [];

  commandSubscribtion: Subscription;

  constructor(private cartService: CartService,
    private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.commandSubscribtion = this.componentConnection.currentCommand.subscribe(command => {
      if (command == 'refreshCart') {
        this.getCart();
      }
    });

    this.getCart();
  }

  ngOnDestroy() {
    this.commandSubscribtion.unsubscribe();
  }

  getCart() {
    this.cartService.getUserCart().subscribe(result => {
      this.products = result.products;
      this.sum = result.sum;
    });
  }
}
