import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-addres-create',
  templateUrl: './addres-create.component.html',
  styleUrls: ['./addres-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AddresCreateComponent implements OnInit {

  @Output() cancelEvent = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  cancel(){
    this.cancelEvent.emit()
  }

}
