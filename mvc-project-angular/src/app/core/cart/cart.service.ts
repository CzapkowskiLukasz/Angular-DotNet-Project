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

  addProductToCart(request: ChangeProductCartCountRequest): Observable<boolean> {
    return this.http.post<any>(this.baseUrl + '/change-product-count', request).pipe(
      map((val) => val.result)
    );
  }

  addOneProductToCart(productId: number): Observable<boolean> {
    const request: ChangeProductCartCountRequest = {
      productId: productId,
      count: 1
    };

    return this.addProductToCart(request);
  }

  getUserCart(): Observable<GetCartResponse> {
    return this.http.get<GetCartResponse>(this.baseUrl + '/user-cart');
  }
}
