import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContinentService {

  baseUrl = `${environment.api_url}/continent`;

  constructor(private http: HttpClient) { }

  getList(): Observable<any> {
    return this.http.get<any[]>(this.baseUrl);
  }
}
