import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ProductListItem } from 'src/app/shared/models/product-list-item';

@Component({
  selector: 'app-admin-product-list',
  templateUrl: './admin-product-list.component.html',
  styleUrls: ['./admin-product-list.component.css']
})
export class AdminProductListComponent implements OnInit {

  @Output() createProductEvent = new EventEmitter();

  products: ProductListItem[] = [];

  deleteComponent: boolean = false;

  constructor() { }

  ngOnInit(): void {
    this.products = [
      {
        productId: 1,
        name: 'test1',
        category: 'testowa1',
        price: 23,
        warehouseQuantity: 4
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      },
      {
        productId: 2,
        name: 'test2',
        category: 'testowa1',
        price: 365,
        warehouseQuantity: 100
      }
    ]
  }

  onProductAdd(){
    this.createProductEvent.emit();
  }

  showDelete() {
    this.deleteComponent = true;
  }
}
