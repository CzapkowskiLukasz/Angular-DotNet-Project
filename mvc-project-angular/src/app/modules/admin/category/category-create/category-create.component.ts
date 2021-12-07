import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
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

  @Input() editedCategoryId;

  @Output() createCategoryEvent = new EventEmitter();

  @Output() cancelEvent = new EventEmitter();

  form: FormGroup;

  parentId;
  categoryList: FilteredDropdownListItem[] = [];

  isCategoriesLoaded: boolean = false;

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService) {
    this.form = fb.group({
      name: [''],
      parent: ['']
    });
  }

  ngOnInit(): void {
    this.fetchCategories();

    if (this.isItEditing) {
      this.fetchCategory();
    }
  }

  submit() {
    if (this.isItEditing) {
      let category = {
        categoryId: this.editedCategoryId,
        name: this.form.get('name').value,
        parentId: this.parentId
      };

      this.categoryService.update(category).subscribe(() =>
        this.createCategoryEvent.emit(),
        err => console.log(err));
    } else {
      let newCategory = {
        name: this.form.get('name').value,
        parentId: this.parentId
      };

      this.categoryService.add(newCategory).subscribe(() =>
        this.createCategoryEvent.emit(),
        err => console.log(err));
    }
  }

  cancel() {
    this.cancelEvent.emit();
  }

  selectParent(id) {
    this.parentId = id;
  }

  get isItEditing(): boolean {
    return this.editedCategoryId != undefined;
  }

  private fetchCategories() {
    this.categoryService.getAdminDropdownList().subscribe(result =>
      this.categoryList = result.categories.map(c => ({
        text: c.name,
        value: c.categoryId
      })),
      err => console.log(err),
      () => this.isCategoriesLoaded = true);
  }

  private fetchCategory() {
    this.categoryService.getById(this.editedCategoryId).subscribe(result => {
      this.form.get('name').setValue(result.name);

      let parent = this.categoryList.find(x =>
        x.value == result.parentId);

      this.form.get('parent').setValue(parent.text);
      this.parentId = parent.value;
    });
  }
}
