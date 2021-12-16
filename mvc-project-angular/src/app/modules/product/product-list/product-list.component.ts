import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  constructor(private route: ActivatedRoute, private productService: ProductService) {

  }

  ngOnInit(): void {
    this.getProduct()
  }

  getProduct(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.fetchProducts(id)
  }

  fetchProducts(categoryId) {
    this.productService.getProductsByCategoryIdList(categoryId).subscribe(result => {
      this.products = result.products;
    });
  }
}
