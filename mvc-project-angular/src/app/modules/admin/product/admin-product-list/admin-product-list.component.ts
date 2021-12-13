import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { ProductService } from 'src/app/core/product/product.service';
import { ProductListItem } from 'src/app/shared/models/product-list-item';

@Component({
  selector: 'app-admin-product-list',
  templateUrl: './admin-product-list.component.html',
  styleUrls: ['./admin-product-list.component.css']
})
export class AdminProductListComponent implements OnInit, OnDestroy {

  commandSubscribtion: Subscription;

  itemForDeleteId;

  products: ProductListItem[] = [];

  deleteComponent: boolean = false;

  constructor(private productService: ProductService,
    private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.fetchProducts();
  }

  ngOnDestroy() {
    if (this.commandSubscribtion)
      this.commandSubscribtion.unsubscribe();
  }

  fetchProducts() {
    this.productService.getAdminList().subscribe(result => {
      this.products = result.products;
    });
  }

  openForm(id) {
    const preparedValue = {
      key: 'productId',
      value: id
    };

    this.componentConnection.sendValue(preparedValue);
    this.componentConnection.sendCommand('openForm');
    this.setSubscribtion();
  }

  addDiscount() {
  }

  deleteProduct(id) {
  }

  private setSubscribtion() {
    if (!this.commandSubscribtion) {
      this.commandSubscribtion = this.componentConnection.currentCommand.subscribe(command => {
        if (command == 'fetch') {
          this.fetchProducts();
        } else if (command == 'deleteConfirm') {
          this.finishDelete();
        }
      });
    }
  }

  private finishDelete() {
    // this.productService.delete(this.itemForDeleteId).subscribe(result => {
    //   if (result) {
    //     console.log('Successful delete');
    //     this.fetchCategories();
    //   }
    // });
  }
}
