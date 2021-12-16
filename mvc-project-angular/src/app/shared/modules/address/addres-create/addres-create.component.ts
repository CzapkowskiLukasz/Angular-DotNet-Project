import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddressService } from 'src/app/core/address/address.service';
import { UserService } from 'src/app/core/user/user.service';
import { Address } from 'src/app/shared/models/address';

@Component({
  selector: 'app-addres-create',
  templateUrl: './addres-create.component.html',
  styleUrls: ['./addres-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AddresCreateComponent implements OnInit {

  @Output() cancelEvent = new EventEmitter();

  @Input() userId

  form: FormGroup;

  address = new Address()

  constructor(private fb: FormBuilder, private addressService: AddressService, protected router: Router, private userService: UserService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      street: ['', Validators.required],
      houseNumber: ['', Validators.required],
      apartmentNumber: [''],
      code: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required]
    });
  }

  cancel(){
    this.cancelEvent.emit()
  }

  save(){
    const formData = this.form.value;

    this.address.userId = this.userId
    this.address.street = formData.street;
    this.address.buildingNumber = formData.houseNumber;
    this.address.apartmentNumber = formData.apartmentNumber;
    this.address.zipCode = formData.code;
    this.address.city = formData.city;
    this.address.country = formData.country;

    this.addressService.add(this.address).subscribe(result => {
      if (result.result)
        this.cancel()
    });
  }

}
