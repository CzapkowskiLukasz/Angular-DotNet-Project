import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FilteredDropdownListItem } from 'src/app/shared/models/filtered-dropdown-list-item';

@Component({
  selector: 'app-admin-product-create',
  templateUrl: './admin-product-create.component.html',
  styleUrls: ['./admin-product-create.component.css']
})
export class AdminProductCreateComponent implements OnInit {

  form: FormGroup;

  categoryId;

  categoryList: FilteredDropdownListItem[] = [];

  producerId;

  producerList: FilteredDropdownListItem[] = [];

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      name: [''],
      price: [''],
      warehouseQuantity: [''],
      expert: [''],
      description: [''],
      category: [''],
      producer: ['']
    });
  }

  ngOnInit(): void {
    this.fetchCategories();
    this.fetchProducers2();
  }

  selectCategory(id: string) {
    this.categoryId = id;
    console.log(`category: ${this.categoryId}`);
  }

  selectProducer(id: string) {
    this.producerId = id;
  }

  submit(): void {

  }

  private fetchCategories() {
    this.categoryList = [
      {
        value: '1',
        text: 'cat1'
      }, {
        value: '2',
        text: 'cat2'
      }
    ];
  }

  private fetchProducers() {
    this.producerList = [
      {
        value: '1',
        text: 'Producer 1'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '3',
        text: 'Producer 3'
      }];
  }

  private fetchProducers2() {
    this.producerList = [
      {
        value: '1',
        text: 'Producer 1'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '3',
        text: 'Producer 3aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '3',
        text: 'Producer 3'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '3',
        text: 'Producer 3'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '3',
        text: 'Producer 3'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '3',
        text: 'Producer 3'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '3',
        text: 'Producer 3'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '3',
        text: 'Producer 3'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '3',
        text: 'Producer 3'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '2',
        text: 'Producer 2'
      }, {
        value: '3',
        text: 'Producer 3'
      }, {
        value: '2',
        text: 'Producer 2'
      },
    ];
  }
}
