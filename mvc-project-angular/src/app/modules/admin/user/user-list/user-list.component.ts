import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class UserListComponent implements OnInit {

  @Output() createUserInfoEvent = new EventEmitter();

  @Output() createVoucherEvent = new EventEmitter();

  @Output() cancelVoucherEvent = new EventEmitter();
  
  constructor() { }

  ngOnInit(): void {
  }

  showUserInfo(){
    this.createUserInfoEvent.emit()
  }

  showCreateVoucherEvent(){
    this.createVoucherEvent.emit();
  }
}