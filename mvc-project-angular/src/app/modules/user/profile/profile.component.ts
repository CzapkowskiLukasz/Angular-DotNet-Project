import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { AddressService } from 'src/app/core/address/address.service';
import { LocalTranslateService } from 'src/app/core/internationalization/local-translate.service';
import { UserService } from 'src/app/core/user/user.service';
import { Address } from 'src/app/shared/models/address';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProfileComponent implements OnInit {
  count: number;
  showCart: boolean;

  addresses: Address[] = []

  addAddress: boolean;

  constructor(private userService: UserService,
    private router: Router, private addressService: AddressService) {
    this.addAddress = false;
    this.count = 0;
    this.showCart = false;
  }

  ngOnInit(): void {
    this.addressService.getByUserId(this.userService.getUserId()).subscribe(result => {
      this.addresses = result.addresses
    });
  }

  showAddAddress() {
    this.addAddress = true
  }

  hideAddAddress() {
    this.addAddress = false;
  }

  increse() {
    this.count += 1;
  }

  logout() {
    this.userService.logout();
    this.router.navigate(['']);
  }
}
