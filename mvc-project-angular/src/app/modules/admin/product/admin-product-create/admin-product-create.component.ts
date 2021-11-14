import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { FilteredDropdownListItem } from 'src/app/shared/models/filtered-dropdown-list-item';

@Component({
  selector: 'app-admin-product-create',
  templateUrl: './admin-product-create.component.html',
  styleUrls: ['./admin-product-create.component.css']
})
export class AdminProductCreateComponent implements OnInit {

  form: FormGroup;

  searchCategoryControl: FormControl;
  searchCategoryFilterText = '';

  searchCategoryList: FilteredDropdownListItem[] = [];

  categoriesNotFetched = false;

  selectedCategoryId?: number;

  dropdownShown = false;

  catInputSub;

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      name: [''],
      price: [''],
      warehouseQuantity: [''],
      expertId: [''],
      description: [''],
      categoryId: [''],
      producerId: ['']
    });

    this.searchCategoryControl = new FormControl('');
  }

  ngOnInit(): void {
    this.getSearchList();

  }

  submit(): void {

  }

  private getSearchList() {
    this.searchCategoryList = [
      {
        value: '1',
        text: 'cat1'
      }, {
        value: '2',
        text: 'cat2'
      }
    ];
  }
}
