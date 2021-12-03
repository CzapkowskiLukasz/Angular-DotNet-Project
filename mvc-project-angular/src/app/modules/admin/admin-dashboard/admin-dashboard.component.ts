import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { AdminProductCreateComponent } from '../product/admin-product-create/admin-product-create.component';
import { AdminProductListComponent } from '../product/admin-product-list/admin-product-list.component';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AdminDashboardComponent implements OnInit {

  @ViewChild(AdminProductListComponent) productListComponent: AdminProductListComponent;

  mainComponent: string;
  secondComponent: string;

  itemForDeleteName: string;

  count: number;
  showCart: boolean;

  productBookmark: boolean;
  userBookmark: boolean;
  bargainBookmark: boolean;
  producerBookmark: boolean;
  countryBookmark: boolean;
  deliveryBookmark: boolean;

  constructor() {
    this.count = 0;
    this.showCart = false;
    this.mainComponent = 'products';
    this.secondComponent = 'statistics';
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
    this.secondComponent = 'addProduct';
  }

  onOpenUserInfoCard() {
    this.secondComponent = 'userInfo';
  }

  onOpenCreateVoucher() {
    this.secondComponent = 'addVoucher';
  }

  onCreateProduct() {
    this.productListComponent.fetchProducts();
    this.onCancelCard();
  }

  onOpenDeleteProductConfirm(id) {
    this.itemForDeleteName = `product with id = ${id}`;
    this.secondComponent = 'delete';
  }

  onOpenAddCountry() {
    this.secondComponent = 'addCountry';
  }

  onDelete() {
    this.onCancelCard();
  }

  onCancelCard() {
    this.secondComponent = 'statistics';
  }

  showUsers() {
    this.mainComponent = 'users';
    this.productBookmark = false;
    this.userBookmark = true;
    this.bargainBookmark = false;
    this.producerBookmark = false;
    this.countryBookmark = false;
    this.deliveryBookmark = false;
  }

  showProducts() {
    this.mainComponent = 'products';
    this.productBookmark = true;
    this.userBookmark = false;
    this.bargainBookmark = false;
    this.producerBookmark = false;
    this.countryBookmark = false;
    this.deliveryBookmark = false;
  }

  showBargains() {
    this.mainComponent = 'bargains';
    this.productBookmark = false;
    this.userBookmark = false;
    this.bargainBookmark = true;
    this.producerBookmark = false;
    this.countryBookmark = false;
    this.deliveryBookmark = false;
  }

  showProducers() {
    this.mainComponent = 'producers';
    this.productBookmark = false;
    this.userBookmark = false;
    this.bargainBookmark = false;
    this.producerBookmark = true;
    this.countryBookmark = false;
    this.deliveryBookmark = false;
  }

  showCountries() {
    this.mainComponent = 'countries';
    this.productBookmark = false;
    this.userBookmark = false;
    this.bargainBookmark = false;
    this.producerBookmark = false;
    this.countryBookmark = true;
    this.deliveryBookmark = false;
  }

  showDelivery() {
    this.mainComponent = 'deliveries';
    this.productBookmark = false;
    this.userBookmark = false;
    this.bargainBookmark = false;
    this.producerBookmark = false;
    this.countryBookmark = false;
    this.deliveryBookmark = true;
  }

  showCategories() {
    this.mainComponent = 'categories';
    this.productBookmark = false;
    this.userBookmark = false;
    this.bargainBookmark = false;
    this.producerBookmark = false;
    this.countryBookmark = false;
    this.deliveryBookmark = true;
  }
}
