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
  producerBookmark : boolean;
  countryBookmark: boolean;
  deliveryBookmark: boolean;

  constructor() {
    this.count = 0;
    this.showCart = false;
    this.card = 'statistics';
    this.productBookmark = true;
    this.userBookmark = false;
    this.bargainBookmark = false;
    this.producerBookmark = false;
    this.countryBookmark = false;
    this.deliveryBookmark = false;
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

  onOpenCreateVoucher(){
    this.card = 'addVoucher';
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
    this.producerBookmark = false;
    this.countryBookmark = false;
    this.deliveryBookmark = false;
  }

  showProducts(){
    this.productBookmark = true;
    this.userBookmark = false;
    this.bargainBookmark = false;
    this.producerBookmark = false;
    this.countryBookmark = false;
    this.deliveryBookmark = false;
  }

  showBargains(){
    this.productBookmark = false;
    this.userBookmark = false;
    this.bargainBookmark = true;
    this.producerBookmark = false;
    this.countryBookmark = false;
    this.deliveryBookmark = false;
  }

  showProducers(){
    this.productBookmark = false;
    this.userBookmark = false;
    this.bargainBookmark = false;
    this.producerBookmark = true;
    this.countryBookmark = false;
    this.deliveryBookmark = false;
  }

  showCountries(){
    this.productBookmark = false;
    this.userBookmark = false;
    this.bargainBookmark = false;
    this.producerBookmark = false;
    this.countryBookmark = true;
    this.deliveryBookmark = false;
  }

  showDelivery(){
    this.productBookmark = false;
    this.userBookmark = false;
    this.bargainBookmark = false;
    this.producerBookmark = false;
    this.countryBookmark = false;
    this.deliveryBookmark = true;
  }
}
