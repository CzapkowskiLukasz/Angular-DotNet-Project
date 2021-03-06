import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CategoryListComponent implements OnInit {

  @Output() createCategoryEvent = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  addCategory(){
    this.createCategoryEvent.emit()
  }
}
