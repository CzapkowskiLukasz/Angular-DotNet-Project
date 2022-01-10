import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';

@Component({
  selector: 'app-admin-delete-confirm',
  templateUrl: './admin-delete-confirm.component.html',
  styleUrls: ['./admin-delete-confirm.component.css'],
  encapsulation: ViewEncapsulation.Emulated
})
export class AdminDeleteConfirmComponent implements OnInit {

  itemName;

  valueSubscribtion: Subscription;

  constructor(private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.valueSubscribtion = this.componentConnection.lastValue.subscribe(obj => {
      if (obj.key == "itemForDeleteName") {
        this.itemName = obj.value;
      }
    });
  }

  ngOnDestroy(){
    this.valueSubscribtion.unsubscribe();
  }

  submit() {
    this.componentConnection.sendCommand('deleteConfirm');
    this.cancel();
  }

  cancel() {
    this.componentConnection.sendCommand('closeForm');
  }
}
