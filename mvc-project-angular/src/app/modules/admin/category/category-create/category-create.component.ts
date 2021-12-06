import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CategoryService } from 'src/app/core/category/category.service';
import { FilteredDropdownListItem } from 'src/app/shared/models/filtered-dropdown-list-item';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CategoryCreateComponent implements OnInit {

  @Output() createCategoryEvent = new EventEmitter();

  @Output() cancelEvent = new EventEmitter();

  form: FormGroup;

  parentId;
  categoryList: FilteredDropdownListItem[] = [];

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService) {
    this.form = fb.group({
      name: [''],
      parent: ['']
    });
  }

  ngOnInit(): void {
    this.fetchCategories();
  }

  submit() {
    let newCategory = {
      name: this.form.get('name').value,
      parentId: this.parentId
    };

    this.categoryService.add(newCategory).subscribe(() =>
      this.createCategoryEvent.emit(),
      err => console.log(err));
  }

  cancel() {
    this.cancelEvent.emit();
  }

  private fetchCategories() {
    this.categoryService.getAdminDropdownList().subscribe(result =>
      this.categoryList = result.categories);
  }
}
