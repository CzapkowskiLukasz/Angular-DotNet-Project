import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { CategoryService } from 'src/app/core/category/category.service';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { CategoryListItem } from 'src/app/shared/models/category-list-item';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CategoryListComponent implements OnInit {

  @Output() deleteEvent = new EventEmitter();

  commandSubscribtion: Subscription;

  categories: CategoryListItem[] = [];

  constructor(private categoryService: CategoryService,
    private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.fetchCategories();
  }

  ngOnDestroy() {
    this.commandSubscribtion.unsubscribe();
  }

  deleteCategory(categoryId) {
    this.deleteEvent.emit(categoryId);
  }

  openForm(id) {
    const preparedValue = {
      key: 'categoryId',
      value: id
    };

    this.componentConnection.sendValue(preparedValue);
    this.componentConnection.sendCommand('openForm');
    this.setSubscribtion();
  }

  setSubscribtion() {
    if (!this.commandSubscribtion) {
      this.commandSubscribtion = this.componentConnection.currentCommand.subscribe(command => {
        if (command == 'fetch')
          this.fetchCategories();
      });
    }
  }

  fetchCategories() {
    this.categoryService.getAdminList().subscribe(result =>
      this.categories = result.categories);
  }
}
