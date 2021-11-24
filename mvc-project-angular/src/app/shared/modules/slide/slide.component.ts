import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-slide',
  templateUrl: './slide.component.html',
  styleUrls: ['./slide.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class SlideComponent implements OnInit {
  cartButton: boolean

  constructor() { 
    this.cartButton = false
  }

  ngOnInit(): void {
  }

  showButton(){
    this.cartButton = true
  }

  hideButton(){
    this.cartButton = false
  }
}
