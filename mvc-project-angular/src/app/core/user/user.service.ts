import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { UserListItem } from 'src/app/shared/models/user-list-item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseAdminUrl = `${environment.api_url}/admin/user`;

  baseGlobalUrl = `${environment.api_url}/user`;

  constructor(private http: HttpClient,
    private cookieService: CookieService) { }

  getAdminList(): Observable<any> {
    return this.http.get<UserListItem[]>(this.baseAdminUrl);
  }

  login(request): Observable<any> {
    return this.http.post<any>(this.baseGlobalUrl + '/login', request)
      .pipe(
        tap(result => {
          this.cookieService.set('jwt-authorization', 'true');
          this.cookieService.set('jwt-token', result.token);
        })
      );
  }
}
