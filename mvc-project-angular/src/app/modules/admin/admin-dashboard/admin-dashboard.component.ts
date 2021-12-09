import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { CategoryListComponent } from '../category/category-list/category-list.component';
import { CountryListComponent } from '../countries/country-list/country-list.component';
import { ProducersListComponent } from '../producers/producers-list/producers-list.component';
import { AdminProductListComponent } from '../product/admin-product-list/admin-product-list.component';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AdminDashboardComponent implements OnInit {


  @ViewChild(AdminProductListComponent) productListComponent: AdminProductListComponent;

  @ViewChild(ProducersListComponent) producerListComponent: ProducersListComponent;

  mainComponent: string;
  secondComponent: string;

  itemForDeleteName: string;

  count: number;
  showCart: boolean;

  commandSubscribtion: Subscription;

  constructor(private componentConnection: ComponentConnectionService) {
  }

  ngOnInit(): void {
    this.count = 0;
    this.showCart = false;
    this.mainComponent = 'products';
    this.openDefaultSecondComponent();

    this.commandSubscribtion = this.componentConnection.currentCommand.subscribe(command => {
      if (command == 'closeForm') {
        this.openDefaultSecondComponent();
      }
      else if (command == 'openForm') {
        this.openForm();
      }
      else if (command == 'openDelete') {
        this.secondComponent = 'delete';
      }
    });
  }

  ngOnDestroy() {
    this.commandSubscribtion.unsubscribe();
  }

  increse() {
    this.count += 1;
  }

  openForm() {
    this.secondComponent = 'form';
  }

  openDefaultSecondComponent() {
    this.secondComponent = 'statistics';
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

  onCreateProducer() {
    this.producerListComponent.fetchProducers();
    this.onCancelCard();
  }

  onOpenDeleteProductConfirm(id) {
    this.itemForDeleteName = `product with id = ${id}`;
    this.secondComponent = 'delete';
  }

  onOpenAddCountry() {
    this.secondComponent = 'addCountry';
  }

  onOpenAddCategory() {
    this.secondComponent = 'create';
  }

  onOpenCreateProducer() {
    this.secondComponent = 'addProducer'
  }

  onOpenCreateDiscount() {
    this.secondComponent = 'addDiscount'
  }

  onDelete() {
    this.onCancelCard();
  }

  onCancelCard() {
    this.secondComponent = 'statistics';
  }

  showUsers() {
    this.secondComponent = 'statistics'
    this.mainComponent = 'users';
  }

  showProducts() {
    this.secondComponent = 'statistics'
    this.mainComponent = 'products';
  }

  showBargains() {
    this.secondComponent = 'statistics'
    this.mainComponent = 'bargains';
  }

  showProducers() {
    this.secondComponent = 'statistics'
    this.mainComponent = 'producers';
  }

  showCountries() {
    this.secondComponent = 'statistics'
    this.mainComponent = 'countries';
  }

  showDelivery() {
    this.secondComponent = 'statistics'
    this.mainComponent = 'deliveries';
  }

  showCategories() {
    this.secondComponent = 'statistics'
    this.mainComponent = 'categories';
  }
}
