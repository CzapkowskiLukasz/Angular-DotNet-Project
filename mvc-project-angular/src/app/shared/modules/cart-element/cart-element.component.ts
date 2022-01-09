import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { CartItem } from '../../models/cart-item';

@Component({
  selector: 'app-cart-element',
  templateUrl: './cart-element.component.html',
  styleUrls: ['./cart-element.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CartElementComponent implements OnInit {

  @Input() item: CartItem;

  constructor() { }

  ngOnInit(): void {
  }

}
