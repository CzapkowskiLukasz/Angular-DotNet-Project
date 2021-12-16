import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-address-slide',
  templateUrl: './address-slide.component.html',
  styleUrls: ['./address-slide.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AddressSlideComponent implements OnInit {

  @Input() item
  constructor() { }

  ngOnInit(): void {
  }

}
