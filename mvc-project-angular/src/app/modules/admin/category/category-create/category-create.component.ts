import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { CategoryService } from 'src/app/core/category/category.service';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { FilteredDropdownListItem } from 'src/app/shared/models/filtered-dropdown-list-item';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CategoryCreateComponent implements OnInit {

  form: FormGroup;

  parentId;

  categoryList: FilteredDropdownListItem[] = [];

  isCategoriesLoaded: boolean = false;

  editedCategoryId;

  commandSubscribtion: Subscription;
  valueSubscribtion: Subscription;

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService,
    private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [''],
      parent: ['']
    });

    this.fetchCategories();

    this.valueSubscribtion = this.componentConnection.lastValue.subscribe(obj => {
      if (obj.key == 'categoryId') {
        this.editedCategoryId = obj.value
        this.prepareForm();
      }
    });
  }

  ngOnDestroy() {
    this.valueSubscribtion.unsubscribe();
  }

  submit() {
    if (this.isItEditing) {
      let category = {
        categoryId: this.editedCategoryId,
        name: this.form.get('name').value,
        parentId: this.parentId
      };

      this.categoryService.update(category).subscribe(() =>
        this.finish(),
        err => console.log(err));
    } else {
      let newCategory = {
        name: this.form.get('name').value,
        parentId: this.parentId
      };

      this.categoryService.add(newCategory).subscribe(() =>
        this.finish(),
        err => console.log(err));
    }
  }

  cancel() {
    this.componentConnection.sendCommand('closeForm');
  }

  finish() {
    this.componentConnection.sendCommand('fetch');
    this.cancel();
  }

  selectParent(id) {
    this.parentId = id;
  }

  get isItEditing(): boolean {
    return this.editedCategoryId != -1;
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

      if (result.parentId > 0) {
        let parent = this.categoryList.find(x =>
          x.value == result.parentId);

        this.form.get('parent').setValue(parent.text);
        this.parentId = parent.value;
      }
    });
  }

  private prepareForm() {
    this.form.reset('');
    this.parentId = 0;
    if (this.isItEditing) {
      this.fetchCategory();
    }
  }
}
