import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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
}
