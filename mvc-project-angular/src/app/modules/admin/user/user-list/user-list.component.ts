import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { UserService } from 'src/app/core/user/user.service';
import { UserListItem } from 'src/app/shared/models/user-list-item';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class UserListComponent implements OnInit {

  @Output() createUserInfoEvent = new EventEmitter();

  @Output() createVoucherEvent = new EventEmitter();

  users: UserListItem[] = [];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.fetchUsers();
  }

  showUserInfo(user) {
    this.createUserInfoEvent.emit(user)
  }

  showCreateVoucherEvent() {
    this.createVoucherEvent.emit();
  }

  fetchUsers() {
    this.userService.getAdminList().subscribe(result =>
      this.users = result.users);
  }
}
