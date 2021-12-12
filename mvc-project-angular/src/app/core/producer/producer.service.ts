import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProducerListItem } from 'src/app/shared/models/producer-list-item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProducerService {

  baseAdminUrl = `${environment.api_url}/admin/producer`;

  constructor(private http: HttpClient) { }

  getAdminList(): Observable<any> {
    return this.http.get<ProducerListItem[]>(this.baseAdminUrl);
  }

  getDropdownList(): Observable<any> {
    return this.http.get<any[]>(this.baseAdminUrl + '/dropdown');
  }

  add(newProducer): Observable<any> {
    return this.http.post<any>(this.baseAdminUrl, newProducer);
  }

  update(producer): Observable<any> {
    return this.http.put<any>(this.baseAdminUrl, producer);
  }

  delete(producerId): Observable<boolean> {
    return this.http.delete<boolean>(this.baseAdminUrl + "/" + producerId);
  }
}
