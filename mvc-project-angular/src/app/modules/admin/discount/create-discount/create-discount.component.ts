import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-create-discount',
  templateUrl: './create-discount.component.html',
  styleUrls: ['./create-discount.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CreateDiscountComponent implements OnInit {

  @Output() cancelEvent = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  cancel() {
    this.cancelEvent.emit();
  }
}
