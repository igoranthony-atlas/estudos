import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environments';
import { IUserLoginRequest } from '../../models/interfaces/user/IUserLoginRequest';
import { IUserLoginResponse } from '../../models/interfaces/user/IUserLoginResponse';
import { IUserRequest } from '../../models/interfaces/user/IUserRequest';
import { IUserResponse } from '../../models/interfaces/user/IUserResponse';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = environment.API_URL
  constructor(private http: HttpClient, private cookieService: CookieService) { }

  createUser(user: IUserRequest) : Observable<IUserResponse> {
    return this.http.post<IUserResponse>(`${this.apiUrl}/user`, user);
  }
  authUser(user: IUserLoginRequest) : Observable<IUserLoginResponse> {
    return this.http.post<IUserLoginResponse>(`${this.apiUrl}/auth`, user);
  }
  isLoggedIn(): boolean {
    const JWT_TOKEN = this.cookieService.get('USER_INFO');
    return JWT_TOKEN ? true : false;
  }
}
