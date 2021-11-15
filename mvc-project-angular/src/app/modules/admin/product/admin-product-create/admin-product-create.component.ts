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

  categoryId;

  categoryList: FilteredDropdownListItem[] = [];

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

  }

  selectCategory(id: string) {
    this.categoryId = id;
    console.log(`category: ${this.categoryId}`);
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
}
