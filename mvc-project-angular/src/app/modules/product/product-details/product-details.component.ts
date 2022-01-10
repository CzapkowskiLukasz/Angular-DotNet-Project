import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CartService } from 'src/app/core/cart/cart.service';
import { ProductService } from 'src/app/core/product/product.service';
import { ProductDetails } from 'src/app/shared/models/product';
import { ChangeProductCartCountRequest } from 'src/app/shared/models/requests/changeProductCartCountRequest';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProductDetailsComponent implements OnInit {

  id$

  apiUrl = environment.api_url;

  product?: ProductDetails

  cartCount: number;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService,
    private cartService: CartService) {
  }

  ngOnInit(): void {
    this.getProduct();
    this.cartCount = 1;
  }

  getProduct(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.productService.getDetails(id)
      .subscribe(product => this.product = product);
  }

  increaseCartCount() {
    if (this.cartCount < this.product.warehouseQuantity)
      this.cartCount++;
  }

  decreaseCartCount() {
    if (this.cartCount > 1)
      this.cartCount--;
  }

  addProductToCart() {
    const request: ChangeProductCartCountRequest = {
      productId: this.product.productId,
      count: this.cartCount,
    };

    this.cartService.changeProductCartCount(request).subscribe(result => {
      if (result)
        this.router.navigate(['cart/checkout']);
    });
  }

  // getProduct(id) {
  //   this.productService.getDetails(+id).subscribe(result => {
  //     this.product.name = result.name
  //     this.product.price = result.price
  //     this.product.count = result.count
  //     this.product.producerName = result.producerName
  //   });
  // }
}
