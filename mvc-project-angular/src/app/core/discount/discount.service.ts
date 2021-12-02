import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DiscountListItem } from 'src/app/shared/models/discount-list-item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DiscountService {

  constructor(private http: HttpClient) { }

  getAdminList(): Observable<any> {
    return this.http.get<DiscountListItem[]>(environment.api_url + '/admin/discounts');
  }
}
