import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ChangeProductCartCountRequest } from 'src/app/shared/models/requests/changeProductCartCountRequest';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  baseUrl = `${environment.api_url}/customer/cart`;

  constructor(private http: HttpClient) { }

  addProductToCart(request: ChangeProductCartCountRequest): Observable<boolean> {
    return this.http.post<any>(this.baseUrl + '/add-product', request).pipe(
      map((val) => val.result)
    );
  }
}
