import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AdminDashboardComponent implements OnInit {

  card: string;

  itemForDeleteName: string;

  count: number;
  showCart: boolean;

  constructor() {
    this.count = 0;
    this.showCart = false;
    this.card = 'statistics';
  }

  ngOnInit(): void {
  }

  increse() {
    this.count += 1;
  }

  onOpenCreateProductCard() {
    this.card = 'addProduct';
  }

  onCreateProduct() {
    this.onCancelCard();
  }

  onOpenDeleteProductConfirm(id) {
    this.itemForDeleteName = `product with id = ${id}`;
    this.card = 'delete';
  }

  onDelete() {
    this.onCancelCard();
  }

  onCancelCard() {
    this.card = 'statistics';
  }
}
