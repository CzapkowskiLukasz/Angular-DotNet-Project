import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { CartService } from 'src/app/core/cart/cart.service';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { CartItem } from '../../models/cart-item';
import { ChangeProductCartCountRequest } from '../../models/requests/changeProductCartCountRequest';

@Component({
  selector: 'app-cart-element',
  templateUrl: './cart-element.component.html',
  styleUrls: ['./cart-element.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CartElementComponent implements OnInit {

  @Input() item: CartItem;

  constructor(private cartService: CartService,
    private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
  }

  addOneProduct() {
    this.changeCount(1);
  }

  subtractOneProduct() {
    this.changeCount(-1);
  }

  removeProduct(){
    this.changeCount(-this.item.count);
  }

  changeCount(count: number) {
    const request: ChangeProductCartCountRequest = {
      productId: this.item.productId,
      count: count
    };

    this.cartService.changeProductCartCount(request).subscribe(result => {
      if (result) {
        this.componentConnection.sendCommand('refreshCart');
      }
    })
  }
}
