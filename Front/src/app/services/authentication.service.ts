import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/enviroments/environment.development';
import { LoginModel } from '../interfaces/login-model';
import { RegistrationModel } from '../interfaces/registration-model';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  apiUrl: string = environment.Url + 'api/Authentication/';
  vendedorId?: string;
  private isLoggedInSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public isLoggedIn$: Observable<boolean> = this.isLoggedInSubject.asObservable();

  constructor(private http: HttpClient) {
    // Verificar si el usuario está autenticado al iniciar el servicio
    this.checkAuthenticated();
  }
  login(model: LoginModel): Observable<any> {
    return this.http.post<any>(this.apiUrl + 'login', model).pipe(
      tap((response) => {
        localStorage.setItem('userId', response.userId); // Almacena el ID del usuario en localStorage
        localStorage.setItem('userData', JSON.stringify(response)); // Almacena la información del usuario en localStorage
        this.isLoggedInSubject.next(true); // Emitir que el usuario está autenticado
      })
    );
  }

  logout(): void {
    localStorage.removeItem('userData');
    this.isLoggedInSubject.next(false); // Emitir que el usuario ya no está autenticado
  }
  private checkAuthenticated(): void {
    const userData = localStorage.getItem('userData');
    this.isLoggedInSubject.next(!!userData); // Emitir si hay información de usuario presente en localStorage
  }


  register(model: RegistrationModel ) {
    const headers = new HttpHeaders({});
    return this.http.post<any>(this.apiUrl + 'registration', model);
  }
}
