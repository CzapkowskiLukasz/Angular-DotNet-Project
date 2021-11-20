import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AdminDashboardComponent implements OnInit {

  deleteComponent: boolean = false;

  count: number;
  showCart: boolean;

  constructor() {
    this.count = 0;
    this.showCart = false;
  }

  ngOnInit(): void {
  }

  increse() {
    this.count += 1;
  }
  showDelete() {
    this.deleteComponent
 = true;
  }

  hideDelete(){
    this.deleteComponent
 = false;
  }
}
