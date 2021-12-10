import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class OrderListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
