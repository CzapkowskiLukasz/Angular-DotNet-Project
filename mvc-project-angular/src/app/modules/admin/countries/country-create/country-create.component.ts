import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-country-create',
  templateUrl: './country-create.component.html',
  styleUrls: ['./country-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CountryCreateComponent implements OnInit {

  @Output() cancelEvent = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  cancel() {
    this.cancelEvent.emit();
  }
}
