import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDetails } from 'src/app/shared/models/product';
import { ProductListItem } from 'src/app/shared/models/product-list-item';
import { SlideItem } from 'src/app/shared/models/slide-item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl = `${environment.api_url}/product`;
  baseAdminUrl = `${environment.api_url}/admin/product`;
  baseCustomerUrl = `${environment.api_url}/customer/product`;

  constructor(private http: HttpClient) { }

  getBestsellers(count): Observable<any> {
    return this.http.get<SlideItem[]>(this.baseCustomerUrl + '/bestsellers/' + count);
  }

  getAdminList(): Observable<any> {
    return this.http.get<ProductListItem[]>(this.baseAdminUrl);
  }

  adminGetById(productId): Observable<any> {
    return this.http.get<any>(this.baseAdminUrl + '/by-id/' + productId);
  }

  add(newProduct): Observable<any> {
    return this.http.post<any>(this.baseAdminUrl, newProduct);
  }

  update(product): Observable<any> {
    return this.http.put<any>(this.baseAdminUrl, product);
  }

  delete(productId): Observable<any> {
    return this.http.delete<any>(this.baseAdminUrl + '/' + productId);
  }

  getDetails(id): Observable<ProductDetails> {
    return this.http.get<ProductDetails>(this.baseUrl + '/by-id/' + id)
  }

  getCustomerList(): Observable<any> {
    return this.http.get<ProductListItem[]>(this.baseUrl);
  }

  getProductsByCategoryIdList(categoryId): Observable<any> {
    return this.http.get<ProductListItem[]>(this.baseUrl + '/by-categoryId/' + categoryId);
  }
}
