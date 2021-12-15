import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { LocalTranslateService } from 'src/app/core/internationalization/local-translate.service';
import { UserService } from 'src/app/core/user/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  count: number;
  showCart: boolean;

  addAddress: boolean;
  constructor(private userService: UserService,
    private router: Router) {
    this.addAddress = false;
    this.count = 0;
    this.showCart = false;
  }

  ngOnInit(): void {
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
