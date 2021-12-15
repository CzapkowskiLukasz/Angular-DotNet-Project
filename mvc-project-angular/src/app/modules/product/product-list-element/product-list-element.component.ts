import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product-list-element',
  templateUrl: './product-list-element.component.html',
  styleUrls: ['./product-list-element.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProductListElementComponent implements OnInit {

  @Input() item;

  showProduct: boolean

  apiUrl = environment.api_url;

  constructor() {
    this.showProduct = false
  }
  ngOnInit(): void {
  }

}
