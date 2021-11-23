import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-delete-confirm',
  templateUrl: './admin-delete-confirm.component.html',
  styleUrls: ['./admin-delete-confirm.component.css']
})
export class AdminDeleteConfirmComponent implements OnInit {

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

}
