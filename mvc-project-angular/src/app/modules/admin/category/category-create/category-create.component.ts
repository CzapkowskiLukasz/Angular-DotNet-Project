import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CategoryCreateComponent implements OnInit {

  @Output() cancelEvent = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  cancel() {
    this.cancelEvent.emit();
  }
}
