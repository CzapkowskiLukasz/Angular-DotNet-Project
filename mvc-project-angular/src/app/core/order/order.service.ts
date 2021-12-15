import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderListItem } from 'src/app/shared/models/order-list-item';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class OrderService {

    baseOrderUrl = `${environment.api_url}/Order`;

    constructor(private http: HttpClient) { }

    getOrderByUserIdList(userId): Observable<any> {
        return this.http.get<OrderListItem[]>(this.baseOrderUrl + '/by-userId/' + userId);
    }
}