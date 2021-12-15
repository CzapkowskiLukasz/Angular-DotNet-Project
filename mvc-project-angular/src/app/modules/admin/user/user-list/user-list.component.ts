import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { UserService } from 'src/app/core/user/user.service';
import { UserListItem } from 'src/app/shared/models/user-list-item';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class UserListComponent implements OnInit {

  commandSubscribtion: Subscription;

  userId

  users: UserListItem[] = [];

  constructor(private userService: UserService, private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.fetchUsers();
  }

  ngOnDestroy() {
    if (this.commandSubscribtion)
      this.commandSubscribtion.unsubscribe();
  }

  // showUserInfo(user) {
  //   this.createUserInfoEvent.emit(user)
  // }

  // showCreateVoucherEvent() {
  //   this.createVoucherEvent.emit();
  // }

  openForm(id) {
    const preparedValue = {
      key: 'userId',
      value: id
    };

    this.componentConnection.sendValue(preparedValue);
    this.componentConnection.sendCommand('userInfo');
    this.setSubscribtion();
  }

  openUserInfo(id) {
    this.userId = id;
    const user = this.users.find(x => x.userId == id)
    const preparedValue = {
      key: 'userInfo',
      value: user
    };

    this.componentConnection.sendValue(preparedValue);
    this.componentConnection.sendCommand('userInfo');
    this.setSubscribtion();
  }

  fetchUsers() {
    this.userService.getAdminList().subscribe(result =>
      this.users = result.users);
  }

  private setSubscribtion() {
    if (!this.commandSubscribtion) {
      this.commandSubscribtion = this.componentConnection.currentCommand.subscribe(command => {
        if (command == 'fetch') {
          this.fetchUsers();
        } 
      });
    }
  }

  }
