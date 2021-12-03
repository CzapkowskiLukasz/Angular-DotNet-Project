import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ProductService } from 'src/app/core/product/product.service';
import { ProductListItem } from 'src/app/shared/models/product-list-item';

@Component({
  selector: 'app-admin-product-list',
  templateUrl: './admin-product-list.component.html',
  styleUrls: ['./admin-product-list.component.css']
})
export class AdminProductListComponent implements OnInit {

  @Output() createProductEvent = new EventEmitter();

  @Output() deleteProductEvent = new EventEmitter();

  @Output() createDiscountEvent = new EventEmitter();

  products: ProductListItem[] = [];

  deleteComponent: boolean = false;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.fetchProducts();
  }

  fetchProducts() {
    this.productService.getAdminList().subscribe(result => {
      this.products = result.products;
    });
  }

  addProduct() {
    this.createProductEvent.emit();
  }

  addDiscount() {
    this.createDiscountEvent.emit();
  }
  
  deleteProduct(id) {
    this.deleteProductEvent.emit(id);
  }

  showDelete() {
    this.deleteComponent = true;
  }
}
