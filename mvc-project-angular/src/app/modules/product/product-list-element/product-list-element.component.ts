import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from 'src/app/core/cart/cart.service';
import { ProductListItem } from 'src/app/shared/models/product-list-item';
import { ChangeProductCartCountRequest } from 'src/app/shared/models/requests/changeProductCartCountRequest';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product-list-element',
  templateUrl: './product-list-element.component.html',
  styleUrls: ['./product-list-element.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProductListElementComponent implements OnInit {

  @Input() item: ProductListItem;

  showProduct: boolean

  apiUrl = environment.api_url;

  constructor(private cartService: CartService,
    private router: Router) {
    this.showProduct = false
  }

  ngOnInit(): void {
  }

  addProductToCart() {
    const request: ChangeProductCartCountRequest = {
      productId: this.item.productId,
      count: 1,
    };

    this.cartService.addProductToCart(request).subscribe(result => {
      if (result) 
        this.router.navigate(['cart/checkout']);
    });
  }
}
