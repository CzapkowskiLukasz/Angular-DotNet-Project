import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddressService } from 'src/app/core/address/address.service';
import { LocalTranslateService } from 'src/app/core/internationalization/local-translate.service';
import { OrderService } from 'src/app/core/order/order.service';
import { UserService } from 'src/app/core/user/user.service';
import { Address } from 'src/app/shared/models/address';
import { OrderListItem } from 'src/app/shared/models/order-list-item';
import { UserListItem } from 'src/app/shared/models/user-list-item';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProfileComponent implements OnInit {
  count: number;
  showCart: boolean;

  users: UserListItem[] =[]

  user: UserListItem

  userId: number

  name

  addresses: Address[] = []

  addAddress: boolean;

  orders: OrderListItem[] = []

  constructor(private userService: UserService,
    private router: Router, private addressService: AddressService, private orderService: OrderService) {
    this.addAddress = false;
    this.count = 0;
    this.showCart = false;
  }

  ngOnInit(): void {
    this.userId = this.userService.getUserId()
    this.addressService.getByUserId(this.userId).subscribe(result => {
      this.addresses = result.addresses
    });

    this.orderService.getOrderByUserIdList(this.userId).subscribe(result => {
      this.orders = result.orders
    })

    this.userService.getUserById(this.userId).subscribe(result => {
      this.user = result
    })

    this.name = this.user.name
  }

  showAddAddress() {
    this.addAddress = true
  }

  hideAddAddress() {
    this.addAddress = false;
    this.addressService.getByUserId(this.userId).subscribe(result => {
      this.addresses = result.addresses
    });
  }

  increse() {
    this.count += 1;
  }

  logout() {
    this.userService.logout();
    this.router.navigate(['']);
  }
}
