import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from 'src/app/shared/models/category';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  baseAdminUrl = `${environment.api_url}/admin/category`;

  constructor(private http: HttpClient) { }

  getAdminDropdownList(): Observable<any> {
    return this.http.get<Category[]>(this.baseAdminUrl + '/dropdown');
  }

  getAdminList(): Observable<any> {
    return this.http.get<Category[]>(this.baseAdminUrl);
  }

  add(newCategory): Observable<any> {
    return this.http.post<any>(this.baseAdminUrl, newCategory);
  }

  getById(id): Observable<any> {
    return this.http.get<any>(this.baseAdminUrl + '/by-id/' + id);
  }

  update(category): Observable<any> {
    return this.http.put<any>(this.baseAdminUrl, category);
  }

  delete(id): Observable<boolean> {
    return this.http.delete<boolean>(this.baseAdminUrl + '/' + id);
  }
}
