import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AddressService } from 'src/app/core/address/address.service';
import { UserService } from 'src/app/core/user/user.service';
import { Address } from 'src/app/shared/models/address';

@Component({
  selector: 'app-cart-checkout',
  templateUrl: './cart-checkout.component.html',
  styleUrls: ['./cart-checkout.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CartCheckoutComponent implements OnInit {
  addresses: Address[] = []
  addAddress: boolean;
  user
  constructor(private addressService: AddressService, private userService: UserService) {
    this.addAddress = false;
  }

  ngOnInit(): void {
    this.addressService.getByUserId(this.userService.getUserId()).subscribe(result => {
      this.addresses = result.addresses
    });

    this.userService.getUserById(this.userService.getUserId()).subscribe(result => {
      this.user = result
    })
  }

  showAddAddress() {
    this.addAddress = true
  }

  hideAddAddress() {
    this.addAddress = false;
    this.addressService.getByUserId(this.userService.getUserId()).subscribe(result => {
      this.addresses = result.addresses
    });
  }
}
