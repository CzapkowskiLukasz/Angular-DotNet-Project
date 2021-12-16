import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { Address } from 'src/app/shared/models/address';

@Component({
  selector: 'app-addres',
  templateUrl: './addres.component.html',
  styleUrls: ['./addres.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AddresComponent implements OnInit {

  @Input() item: Address

  constructor() { }

  ngOnInit(): void {
  }

}
