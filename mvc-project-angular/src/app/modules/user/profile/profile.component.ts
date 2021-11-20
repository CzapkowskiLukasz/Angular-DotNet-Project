import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProfileComponent implements OnInit {
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
}
