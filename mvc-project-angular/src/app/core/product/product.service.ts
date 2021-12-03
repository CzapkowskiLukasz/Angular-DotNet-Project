import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductListItem } from 'src/app/shared/models/product-list-item';
import { SlideItem } from 'src/app/shared/models/slide-item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl = `${environment.api_url}/product`;
  baseAdminUrl=`${environment.api_url}/admin/product`;

  constructor(private http: HttpClient) { }

  getBestsellers(count): Observable<any> {
    return this.http.get<SlideItem[]>(this.baseUrl + '/bestsellers/' + count);
  }

  getAdminList(): Observable<any> {
    return this.http.get<ProductListItem[]>(this.baseAdminUrl);
  }

  add(newProduct):Observable<any>{
    return this.http.post<any>(environment.api_url + '/admin/add-product', newProduct);
  }
}
