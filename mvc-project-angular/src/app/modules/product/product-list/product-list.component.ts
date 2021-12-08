import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductService } from 'src/app/core/product/product.service';
import { ProductListItem } from 'src/app/shared/models/product-list-item';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProductListComponent implements OnInit {

  products: ProductListItem[] = [];

  constructor(private productService: ProductService) {

  }

  ngOnInit(): void {
    this.fetchProducts()
  }

  fetchProducts() {
    this.productService.getAdminList().subscribe(result => {
      this.products = result.products;
    });
  }

}
