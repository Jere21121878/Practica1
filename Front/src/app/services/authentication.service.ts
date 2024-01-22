import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/enviroments/environment.development';
import { LoginModel } from '../interfaces/login-model';
import { RegistrationModel } from '../interfaces/registration-model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  apiUrl: string = environment.Url + 'api/Authentication/';

  constructor(private http: HttpClient) {}

  login(model: LoginModel) {
    return this.http.post<any>(this.apiUrl + 'login', model);
 
}
register(model: RegistrationModel ) {
  const headers = new HttpHeaders({});
  return this.http.post<any>(this.apiUrl + 'registration', model);
}
}
