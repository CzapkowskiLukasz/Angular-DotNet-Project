import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-admin-delete-confirm',
  templateUrl: './admin-delete-confirm.component.html',
  styleUrls: ['./admin-delete-confirm.component.css']
})
export class AdminDeleteConfirmComponent implements OnInit {

  @Input() itemName;

  @Output() deleteEvent = new EventEmitter();

  @Output() cancelEvent = new EventEmitter();

  deleteComponent: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  showDelete() {
    this.deleteComponent = true;
  }

  hideDelete() {
    this.deleteComponent
      = false;
  }

  submit() {
    this.deleteEvent.emit();
  }

  cancel() {
    this.cancelEvent.emit();
  }
}
