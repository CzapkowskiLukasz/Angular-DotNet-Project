import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

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
