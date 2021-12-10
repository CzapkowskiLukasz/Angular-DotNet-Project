import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { ProductService } from 'src/app/core/product/product.service';
import { ProductDetails } from 'src/app/shared/models/product';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProductDetailsComponent implements OnInit {

  id$

  dupa

  product: ProductDetails

  constructor(private route: ActivatedRoute, private productService: ProductService) {
  }

  ngOnInit(): void {
    this.getProduct(5)
  }

  getProduct(id) {
    this.productService.getDetails(+id).subscribe(result => {
      this.product.name = result.name
      this.product.price = result.price
      this.product.count = result.count
      this.product.producerName = result.producerName
    });
  }
}
