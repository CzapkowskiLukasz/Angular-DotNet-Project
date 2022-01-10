import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { OrderService } from 'src/app/core/order/order.service';
import { OrderListItem } from 'src/app/shared/models/order-list-item';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css'],
  encapsulation: ViewEncapsulation.Emulated
})
export class UserInfoComponent implements OnInit {

  itemName;

  orders: OrderListItem[] = []

  valueSubscribtion: Subscription;
  
  constructor(private componentConnection: ComponentConnectionService, private orderService: OrderService) { 
  }

  ngOnInit(): void {
    this.valueSubscribtion = this.componentConnection.lastValue.subscribe(obj => {
      if (obj.key == "userInfo") {
        this.itemName = obj.value;
        this.fetchOrders(this.itemName.userId)
      }
    });
  }

  ngOnDestroy(){
    this.valueSubscribtion.unsubscribe();
  }

  fetchOrders(userId) {
    this.orderService.getOrderByUserIdList(userId).subscribe(result =>
      this.orders = result.orders);
  }
}
