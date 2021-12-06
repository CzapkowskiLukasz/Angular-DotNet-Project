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
