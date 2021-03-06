import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserListItem } from 'src/app/shared/models/user-list-item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseAdminUrl = `${environment.api_url}/admin/user`;

  constructor(private http: HttpClient) { }

  getAdminList(): Observable<any> {
    return this.http.get<UserListItem[]>(this.baseAdminUrl);
  }
}
