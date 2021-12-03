import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CountryListItem } from 'src/app/shared/models/country-list-item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  baseAdminUrl = `${environment.api_url}/admin/country`;

  constructor(private http: HttpClient) { }

  getAdminList(): Observable<any> {
    return this.http.get<CountryListItem[]>(this.baseAdminUrl);
  }
}
