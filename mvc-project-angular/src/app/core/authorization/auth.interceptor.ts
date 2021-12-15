import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserService } from "../user/user.service";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private userService: UserService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.userService.isLogged()) {
            const token = this.userService.getToken();
            const authReq = req.clone({
                headers: req.headers.set('Authorization', 'Bearer ' + token)
            });
            return next.handle(authReq);
        }
        return next.handle(req.clone());
    }
}