import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-user-list-element',
  templateUrl: './user-list-element.component.html',
  styleUrls: ['./user-list-element.component.css'],
  encapsulation: ViewEncapsulation.Emulated
})
export class UserListElementComponent implements OnInit {

  @Input() itemName;

  constructor() { }

  ngOnInit(): void {
  }

}
