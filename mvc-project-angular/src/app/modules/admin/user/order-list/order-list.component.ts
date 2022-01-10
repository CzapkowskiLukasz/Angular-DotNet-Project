import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css'],
  encapsulation: ViewEncapsulation.Emulated
})
export class OrderListComponent implements OnInit {

  @Input() item;
  
  constructor() { }

  ngOnInit(): void {
  }

}
