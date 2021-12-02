import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProducerListItem } from 'src/app/shared/models/producer-list-item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProducerService {

  constructor(private http: HttpClient) { }

  getAdminList(): Observable<any> {
    return this.http.get<ProducerListItem[]>(environment.api_url + '/admin/producers');
  }

  getDropdownList():Observable<any>{
    return this.http.get<any[]>(environment.api_url + '/admin/producers-dropdown');
  }
}
