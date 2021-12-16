import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  baseUrl = `${environment.api_url}/customer/cart/change-product-count`;

  constructor(private http: HttpClient) { }

  changeProductCount(request): Observable<any> {
    return this.http.post<any>(this.baseUrl, request);
  }
}
