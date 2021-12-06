import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { DiscountService } from 'src/app/core/discount/discount.service';
import { DiscountListItem } from 'src/app/shared/models/discount-list-item';

@Component({
  selector: 'app-discount-list',
  templateUrl: './discount-list.component.html',
  styleUrls: ['./discount-list.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class DiscountListComponent implements OnInit {

  @Output() createDiscountEvent = new EventEmitter();

  discounts: DiscountListItem[] = [];

  constructor(private discountService: DiscountService) { }

  ngOnInit(): void {
    this.fetchDiscounts();
  }

  fetchDiscounts() {
    this.discountService.getAdminList().subscribe(result =>
      this.discounts = result.discounts);
  }

  addDiscount() {
    this.createDiscountEvent.emit()
  }
}
