import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroments/environment.development';
import { Foto } from '../interfaces/foto';

@Injectable({
  providedIn: 'root'
})
export class FotoService {
  private myAppUrl: string = environment.Url;
  private myApiUrl: string = 'api/Local/';

  constructor(private http: HttpClient) { }
  getFotosByLocalId(localId: string): Observable<Foto[]> {
    console.log('URL:', `${this.myAppUrl}api/Foto/local/${localId}`); // Ajusta la ruta aquí
  
    return this.http.get<Foto[]>(`${this.myAppUrl}api/Foto/local/${localId}`); // Ajusta la ruta aquí
  }
  
  getFotosByProductoId(productoId: string): Observable<Foto[]> {
    console.log('URL:', `${this.myAppUrl}api/Foto/producto/${productoId}`);
    return this.http.get<Foto[]>(`${this.myAppUrl}api/Foto/producto/${productoId}`);
  }
}
