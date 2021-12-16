import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Address } from 'src/app/shared/models/address';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  private baseUrl = `${environment.api_url}/address`;

  constructor(private http: HttpClient) { }

  add(address): Observable<any> {
    return this.http.post<any>(this.baseUrl, address);
  }

  getByUserId(userId): Observable<any> {
    return this.http.get<Address[]>(this.baseUrl + '/by-userId/' + userId)
  }
}
