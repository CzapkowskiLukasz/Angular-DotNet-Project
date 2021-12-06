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
}
