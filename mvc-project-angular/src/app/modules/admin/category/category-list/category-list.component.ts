import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
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
export class CategoryListComponent implements OnInit, OnDestroy {

  commandSubscribtion: Subscription;

  itemForDeleteId;

  categories: CategoryListItem[] = [];

  constructor(private categoryService: CategoryService,
    private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.fetchCategories();
  }

  ngOnDestroy() {
    this.commandSubscribtion.unsubscribe();
  }

  delete(categoryId) {
    this.itemForDeleteId = categoryId;
    const category = this.categories.find(x => x.categoryId == categoryId)
    const nameForDelete = 'category ' + category.name;
    const preparedValue = {
      key: 'itemForDeleteName',
      value: nameForDelete
    };

    this.componentConnection.sendValue(preparedValue);
    this.componentConnection.sendCommand('openDelete');
    this.setSubscribtion();
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

  private setSubscribtion() {
    if (!this.commandSubscribtion) {
      this.commandSubscribtion = this.componentConnection.currentCommand.subscribe(command => {
        if (command == 'fetch') {
          this.fetchCategories();
        } else if (command == 'deleteConfirm') {
          this.finishDelete();
        }
      });
    }
  }

  private fetchCategories() {
    this.categoryService.getAdminList().subscribe(result =>
      this.categories = result.categories);
  }

  private finishDelete() {
    this.categoryService.delete(this.itemForDeleteId).subscribe(result => {
      if (result) {
        console.log('Successful delete');
        this.fetchCategories();
      }
    });
  }
}
