import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductService } from 'src/app/core/product/product.service';
import { SlideItem } from 'src/app/shared/models/slide-item';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class HomeComponent implements OnInit {
  count: number;
  showCart: boolean;

  // testItems: SlideItem[] = [{
  //   productId: 1,
  //   name: 'ziółko',
  //   isPricePerItem: true,
  //   price: 420
  // },
  // {
  //   productId: 2,
  //   name: 'ziółko 2',
  //   isPricePerItem: true,
  //   price: 214
  // }, {
  //   productId: 3,
  //   name: 'ziółko 3',
  //   isPricePerItem: true,
  //   price: 45
  // }, {
  //   productId: 4,
  //   name: 'ziółko 4',
  //   isPricePerItem: true,
  //   price: 90
  // }];

  bestsellers: SlideItem[] = [];

  constructor(private productService: ProductService) {
    this.count = 0;
    this.showCart = false;
  }

  ngOnInit(): void {
    this.productService.getBestsellers(10).subscribe(result => {
      this.bestsellers = result.bestsellers
    });
  }

  increse() {
    this.count += 1;
  }
}
