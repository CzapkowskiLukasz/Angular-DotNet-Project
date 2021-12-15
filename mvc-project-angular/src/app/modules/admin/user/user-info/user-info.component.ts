import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class UserInfoComponent implements OnInit {

  itemName;

  valueSubscribtion: Subscription;
  
  constructor(private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.valueSubscribtion = this.componentConnection.lastValue.subscribe(obj => {
      if (obj.key == "userInfo") {
        this.itemName = obj.value;
      }
    });
  }

  ngOnDestroy(){
    this.valueSubscribtion.unsubscribe();
  }

}
