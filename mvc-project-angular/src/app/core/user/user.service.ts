import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { RegisterRequest } from 'src/app/shared/models/register-request';
import { UserListItem } from 'src/app/shared/models/user-list-item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseAdminUrl = `${environment.api_url}/admin/user`;

  baseGlobalUrl = `${environment.api_url}/user`;

  private authorizationCookieName = 'jwt-authorization';

  private tokenCookieName = 'jwt-token';

  constructor(private http: HttpClient,
    private cookieService: CookieService) { }

  getAdminList(): Observable<any> {
    return this.http.get<UserListItem[]>(this.baseAdminUrl);
  }

  login(request): Observable<any> {
    return this.http.post<any>(this.baseGlobalUrl + '/login', request)
      .pipe(
        tap(result => this.setAuthCookie(result.token))
      );
  }

  isLogged(): boolean {
    return this.cookieService.get(this.authorizationCookieName) == 'true';
  }

  getToken(): string {
    return this.cookieService.get(this.tokenCookieName);
  }

  getUserId(): number {
    const token = this.getToken();
    const decodedToken = jwtDecode(token);
    return decodedToken['id'];
  }

  logout() {
    this.cookieService.delete(this.authorizationCookieName);
    this.cookieService.delete(this.tokenCookieName);
  }

  register(request: RegisterRequest): Observable<any> {
    return this.http.post<any>(this.baseGlobalUrl + '/register', request)
      .pipe(
        tap(result => this.setAuthCookie(result.token))
      );
  }

  getUserById(userId): Observable<any> {
    return this.http.get<UserListItem>(this.baseAdminUrl + '/by-id/' + userId);
  }

  private setAuthCookie(token) {
    this.cookieService.set(this.authorizationCookieName, 'true');
    this.cookieService.set(this.tokenCookieName, token);
  }
}
