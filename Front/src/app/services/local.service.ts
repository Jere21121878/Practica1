import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Local } from '../interfaces/local';
import { environment } from 'src/enviroments/environment';
import { Foto } from '../interfaces/foto';

@Injectable({
  providedIn: 'root'
})
export class LocalService {
  private myAppUrl: string = environment.Url;
  private myApiUrl: string = 'api/Local/';

  constructor(private http: HttpClient) { }

  getLocal(Id: number): Observable<Local> {
    return this.http.get<Local>(`${this.myAppUrl}${this.myApiUrl}${Id}`);
  }

  deleteLocal(Id: number): Observable<void> {
    return this.http.delete<void>(`${this.myAppUrl}${this.myApiUrl}${Id}`);
  }

  addLocal(local: Local): Observable<Local> {
    return this.http.post<Local>(`${this.myAppUrl}${this.myApiUrl}`, local);
  }

  updateLocal(Id: number, local: Local): Observable<void> {
    return this.http.put<void>(`${this.myAppUrl}${this.myApiUrl}${Id}`, local);
  }

  getlocalsByVendedorId(vendedorId: string): Observable<Local[]> {
    console.log('URL:', `${this.myAppUrl}${this.myApiUrl}vendedor/${vendedorId}`);
    return this.http.get<Local[]>(`${this.myAppUrl}${this.myApiUrl}vendedor/${vendedorId}`);
  }

  getLocalFoto(localId: string): Observable<any> {
    return this.http.get<any>(`${this.myAppUrl}${this.myApiUrl}${localId}/foto`);
  }
  
}
