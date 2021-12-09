import { HttpClient } from '@angular/common/http';
import { getPlatform, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CountryListItem } from 'src/app/shared/models/country-list-item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  baseAdminUrl = `${environment.api_url}/admin/country`;

  baseGlobalUrl = `${environment.api_url}/global/country`;

  constructor(private http: HttpClient) { }

  getAdminList(): Observable<any> {
    return this.http.get<CountryListItem[]>(this.baseAdminUrl);
  }

  getDropdownList(): Observable<any> {
    return this.http.get<CountryListItem[]>(this.baseAdminUrl + '/dropdown');
  }

  add(newCountry): Observable<boolean> {
    return this.http.post<boolean>(this.baseAdminUrl, newCountry);
  }

  getById(countryId): Observable<any> {
    return this.http.get<any>(this.baseGlobalUrl + '/' + countryId);
  }

  update(country): Observable<any> {
    return this.http.put<any>(this.baseAdminUrl, country);
  }
}
