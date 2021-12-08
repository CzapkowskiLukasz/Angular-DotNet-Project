import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-product-list-element',
  templateUrl: './product-list-element.component.html',
  styleUrls: ['./product-list-element.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProductListElementComponent implements OnInit {

  @Input() itemName;

  showProduct: boolean

  constructor() {
    this.showProduct = false
  }
  ngOnInit(): void {
  }

}
