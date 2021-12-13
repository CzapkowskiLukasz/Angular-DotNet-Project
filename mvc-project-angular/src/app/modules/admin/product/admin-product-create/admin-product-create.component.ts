import { Component, EventEmitter, OnDestroy, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { CategoryService } from 'src/app/core/category/category.service';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { ProducerService } from 'src/app/core/producer/producer.service';
import { ProductService } from 'src/app/core/product/product.service';
import { FilteredDropdownListItem } from 'src/app/shared/models/filtered-dropdown-list-item';

@Component({
  selector: 'app-admin-product-create',
  templateUrl: './admin-product-create.component.html',
  styleUrls: ['./admin-product-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AdminProductCreateComponent implements OnInit, OnDestroy {

  form: FormGroup;

  categoryId;

  categoryList: FilteredDropdownListItem[] = [];

  producerId;

  producerList: FilteredDropdownListItem[] = [];

  isCategoriesLoaded: boolean;
  isProducersLoaded: boolean;

  editedProductId;

  valueSubscribtion: Subscription;

  expand: boolean;

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService,
    private producerService: ProducerService,
    private productService: ProductService,
    private componentConnection: ComponentConnectionService
  ) {
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [''],
      price: [''],
      count: [''],
      expert: [''],
      description: [''],
      category: [''],
      producer: ['']
    });

    this.expand = false
    this.isCategoriesLoaded = false;
    this.isProducersLoaded = false;

    this.fetchCategories();
    this.fetchProducers();

    this.valueSubscribtion = this.componentConnection.lastValue.subscribe(obj => {
      if (obj.key == 'productId') {
        this.editedProductId = obj.value
        this.prepareForm();
      }
    });
  }

  ngOnDestroy() {
    this.valueSubscribtion.unsubscribe();
  }

  expandForm() {
    this.expand = !this.expand
  }

  selectCategory(id: string) {
    this.categoryId = id;
    console.log(`category: ${this.categoryId}`);
  }

  selectProducer(id: string) {
    this.producerId = id;
  }

  submit() {
    if (this.isItEditing) {
      // const country = {
      //   countryId: this.editedCountryId,
      //   name: this.form.get('name').value,
      //   continentId: this.continentId
      // };

      // this.countryService.update(country).subscribe(() =>
      //   this.finish(),
      //   err => console.log(err));
    }
    else {
      let newProduct = {
        name: this.form.get('name').value,
        producerId: this.producerId,
        description: this.form.get('description').value,
        price: this.form.get('price').value,
        count: this.form.get('count').value,
        categoryId: this.categoryId
      };

      this.productService.add(newProduct).subscribe(() =>
        this.finish(),
        err => console.log(err));
    }
  }

  close() {
    this.componentConnection.sendCommand('closeForm');
  }

  get isItEditing(): boolean {
    return this.editedProductId != -1;
  }

  private finish() {
    this.componentConnection.sendCommand('fetch');
    this.close();
  }

  private fetchCategories() {
    this.categoryService.getAdminDropdownList().subscribe(result =>
      this.categoryList = result.categories.map(category =>
        ({ text: category.name, value: category.categoryId })),
      err => console.log(err),
      () => this.isCategoriesLoaded = true);
  }

  private fetchProducers() {

    this.producerService.getDropdownList().subscribe(result =>
      this.producerList = result.producers.map(producer =>
        ({ text: producer.name, value: producer.producerId })),
      err => console.log(err),
      () => this.isProducersLoaded = true);
  }

  private prepareForm() {
    this.form.reset('');
    this.categoryId = 0;
    this.producerId = 0;
    if (this.isItEditing) {
      // this.fetchCountry();
    }
  }
}
