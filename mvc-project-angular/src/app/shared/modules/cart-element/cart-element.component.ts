import { Component, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { Subject, Subscription } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
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
export class CartElementComponent implements OnInit, OnDestroy {

  @Input() item: CartItem;

  valueSubject: Subject<void>;

  valueSubscribtion: Subscription;

  changeCountValue: number = 0;

  constructor(private cartService: CartService,
    private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.valueSubject = new Subject();

    this.setSubscribtion();
  }

  ngOnDestroy(): void {
    if (this.valueSubject) {
      this.valueSubscribtion.unsubscribe();
    }
  }

  addOneProduct() {
    this.setValue(1);
  }

  subtractOneProduct() {
    this.setValue(-1);
  }

  removeProduct() {
    this.setValue(-this.item.count);
  }

  private setValue(count: number) {
    this.changeCountValue += count;

    this.valueSubject.next();
  }

  private setSubscribtion() {
    this.valueSubscribtion = this.valueSubject
      .pipe(debounceTime(1000))
      .subscribe(() => this.changeCount());
  }

  private changeCount() {
    this.valueSubject.complete();

    const request: ChangeProductCartCountRequest = {
      productId: this.item.productId,
      count: this.changeCountValue
    };

    this.cartService.changeProductCartCount(request).subscribe(result => {
      if (result) {
        this.componentConnection.sendCommand('refreshCart');
      }
    });
  }
}
