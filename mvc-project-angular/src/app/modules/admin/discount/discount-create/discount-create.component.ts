import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-discount-create',
  templateUrl: './discount-create.component.html',
  styleUrls: ['./discount-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class DiscountCreateComponent implements OnInit {

  @Output() cancelEvent = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  cancel() {
    this.cancelEvent.emit();
  }
}
