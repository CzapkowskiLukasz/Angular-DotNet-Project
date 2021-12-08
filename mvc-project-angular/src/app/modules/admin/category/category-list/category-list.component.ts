import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { CategoryService } from 'src/app/core/category/category.service';
import { CategoryListItem } from 'src/app/shared/models/category-list-item';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CategoryListComponent implements OnInit {

  @Output() createCategoryEvent = new EventEmitter();

  @Output() deleteEvent = new EventEmitter();

  categories: CategoryListItem[] = [];

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.fetchCategories();
  }

  addCategory(editedCategoryId) {
    this.createCategoryEvent.emit(editedCategoryId)
  }

  deleteCategory(categoryId){
    this.deleteEvent.emit(categoryId);
  }

  fetchCategories() {
    this.categoryService.getAdminList().subscribe(result =>
      this.categories = result.categories);
  }
}
