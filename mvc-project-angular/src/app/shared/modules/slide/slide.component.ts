import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SlideItem } from '../../models/slide-item';

@Component({
  selector: 'app-slide',
  templateUrl: './slide.component.html',
  styleUrls: ['./slide.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class SlideComponent implements OnInit {

  @Input() item: SlideItem;

  @Output() checkoutEvent = new EventEmitter<number>();

  cartButton: boolean

  apiUrl = environment.api_url;

  constructor() {
    this.cartButton = false
  }

  ngOnInit(): void {
  }

  showButton() {
    this.cartButton = true
  }

  hideButton() {
    this.cartButton = false
  }

  onCheckout() {
    this.checkoutEvent.emit(this.item.productId);
  }
}
