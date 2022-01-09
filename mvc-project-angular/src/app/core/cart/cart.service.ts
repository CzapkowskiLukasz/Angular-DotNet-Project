import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ChangeProductCartCountRequest } from 'src/app/shared/models/requests/changeProductCartCountRequest';
import { GetCartResponse } from 'src/app/shared/models/get-cart-response';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  baseUrl = `${environment.api_url}/customer/cart`;

  constructor(private http: HttpClient) { }

  changeProductCartCount(request: ChangeProductCartCountRequest): Observable<boolean> {
    return this.http.post<any>(this.baseUrl + '/change-product-count', request).pipe(
      map((val) => val.result)
    );
  }

  getUserCart(): Observable<GetCartResponse> {
    return this.http.get<GetCartResponse>(this.baseUrl + '/user-cart');
  }
}
