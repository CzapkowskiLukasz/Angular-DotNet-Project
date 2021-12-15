import { Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { CategoryService } from 'src/app/core/category/category.service';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { FileService } from 'src/app/core/file/file.service';
import { ProducerService } from 'src/app/core/producer/producer.service';
import { ProductService } from 'src/app/core/product/product.service';
import { FilteredDropdownListItem } from 'src/app/shared/models/filtered-dropdown-list-item';
import { ExpandFormComponent } from '../../shared/expand-form/expand-form.component';

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

  file: File;

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService,
    private producerService: ProducerService,
    private productService: ProductService,
    private fileService: FileService,
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
      producer: [''],
      file: ['']
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
      const product = {
        productId: this.editedProductId,
        name: this.form.get('name').value,
        producerId: this.producerId,
        description: this.form.get('description').value,
        price: this.form.get('price').value,
        count: this.form.get('count').value,
        categoryId: this.categoryId
      };

      this.productService.update(product).subscribe(result =>
        this.checkAndUploadFile(result),
        err => console.log(err));
    }
    else {
      const newProduct = {
        name: this.form.get('name').value,
        producerId: this.producerId,
        description: this.form.get('description').value,
        price: this.form.get('price').value,
        count: this.form.get('count').value,
        categoryId: this.categoryId
      };

      this.productService.add(newProduct).subscribe(result =>
        this.checkAndUploadFile(result),
        err => console.log(err));
    }
  }

  close() {
    this.componentConnection.sendCommand('closeForm');
  }

  onFileSelected(event) {
    this.file = event.target.files[0];
  }

  get isItEditing(): boolean {
    return this.editedProductId != -1;
  }

  get descriptionControl(): any {
    return this.form.get('description');
  }

  get fileControl(): any {
    return this.form.get('file');
  }

  private checkAndUploadFile(result) {
    const productId = result.productId;
    if (productId && this.file) {
      this.fileService.uploadThumbnail(productId, this.file).subscribe(
        () => this.finish(),
        err => console.log(err));
    }
    else {
      this.finish();
    }
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

  private fetchProduct() {
    this.productService.adminGetById(this.editedProductId).subscribe(result => {
      const product = result;

      this.form.patchValue(product);

      const producer = this.producerList.find(x => x.value == product.producerId);
      this.producerId = product.producerId
      this.form.get('producer').setValue(producer.text);

      const category = this.categoryList.find(x => x.value == product.categoryId);
      this.categoryId = product.categoryId
      this.form.get('category').setValue(category.text);
    })
  }

  private prepareForm() {
    this.form.reset('');
    this.categoryId = 0;
    this.producerId = 0;
    if (this.isItEditing) {
      this.fetchProduct();
    }
  }
}
