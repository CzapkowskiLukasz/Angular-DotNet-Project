import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CountryListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}