import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CategoryService } from 'src/app/core/category/category.service';
import { ProducerService } from 'src/app/core/producer/producer.service';
import { ProductService } from 'src/app/core/product/product.service';
import { FilteredDropdownListItem } from 'src/app/shared/models/filtered-dropdown-list-item';

@Component({
  selector: 'app-admin-product-create',
  templateUrl: './admin-product-create.component.html',
  styleUrls: ['./admin-product-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AdminProductCreateComponent implements OnInit {

  @Output() createProductEvent = new EventEmitter();

  @Output() cancelEvent = new EventEmitter();

  form: FormGroup;

  categoryId;

  categoryList: FilteredDropdownListItem[] = [];

  producerId;

  producerList: FilteredDropdownListItem[] = [];

  isCategoriesLoaded: boolean;
  isProducersLoaded: boolean;

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService,
    private producerService: ProducerService,
    private productService: ProductService,
  ) {
    this.form = this.fb.group({
      name: [''],
      price: [''],
      count: [''],
      expert: [''],
      description: [''],
      category: [''],
      producer: ['']
    });

    this.isCategoriesLoaded = false;
    this.isProducersLoaded = false;
  }

  ngOnInit(): void {
    this.fetchCategories();
    this.fetchProducers();
  }

  selectCategory(id: string) {
    this.categoryId = id;
    console.log(`category: ${this.categoryId}`);
  }

  selectProducer(id: string) {
    this.producerId = id;
  }

  submit() {
    let newProduct = {
      name: this.form.get('name').value,
      producerId: this.producerId,
      description: this.form.get('description').value,
      price: this.form.get('price').value,
      count: this.form.get('count').value,
      categoryId: this.categoryId
    };

    this.productService.add(newProduct).subscribe(() => this.createProductEvent.emit(),
      err => console.log(err));
  }

  cancel() {
    this.cancelEvent.emit();
  }

  private fetchCategories() {
    this.categoryService.getAdminList().subscribe(result =>
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
}
