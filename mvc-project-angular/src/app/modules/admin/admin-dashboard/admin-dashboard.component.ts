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

  productBookmark : boolean;
  userBookmark : boolean;
  bargainBookmark : boolean;

  constructor() {
    this.count = 0;
    this.showCart = false;
    this.card = 'statistics';
    this.productBookmark = true;
    this.userBookmark = false;
    this.bargainBookmark = false;
  }

  ngOnInit(): void {
  }

  increse() {
    this.count += 1;
  }

  onOpenCreateProductCard() {
    this.card = 'addProduct';
  }

  onOpenUserInfoCard() {
    this.card = 'userInfo';
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

  showUsers(){
    this.productBookmark = false;
    this.userBookmark = true;
    this.bargainBookmark = false;
  }

  showProducts(){
    this.productBookmark = true;
    this.userBookmark = false;
    this.bargainBookmark = false;
  }

  showBargains(){
    this.productBookmark = false;
    this.userBookmark = false;
    this.bargainBookmark = true;
  }
}
