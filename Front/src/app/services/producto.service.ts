import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Producto } from '../interfaces/producto';
import { environment } from 'src/enviroments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class ProductoService {
  private myAppUrl: string = environment.Url;
  private myApiUrl: string = 'api/Producto/';
  constructor(private http: HttpClient) { }


  getProducto(Id:number):Observable<Producto>{
    return this.http.get<Producto>(`${this.myAppUrl}${this.myApiUrl}${Id}`);

  }
   deleteProducto(Id:number):Observable<void>{
    return this.http.delete<void>(`${this.myAppUrl}${this.myApiUrl}${Id}`);

  }
  addProducto(producto:Producto):Observable<Producto>{
    return this.http.post<Producto>(`${this.myAppUrl}${this.myApiUrl}`, producto)

  }


  updateProducto(Id:number, producto:Producto):Observable<void> {
    return this.http.put<void>(`${this.myAppUrl}${this.myApiUrl}${Id}`, producto);
  }
  getProductosByLocalId(localId: string): Observable<Producto[]> {
    console.log('URL:', `${this.myAppUrl}${this.myApiUrl}local/${localId}`);

    return this.http.get<Producto[]>(`${this.myAppUrl}${this.myApiUrl}local/${localId}`);
  }
  getProductos(): Observable<Producto[]> {
    return this.http.get<Producto[]>(`${this.myAppUrl}${this.myApiUrl}`);
  }
  getProductosBySearchTerm(searchTerm: string): Observable<Producto[]> {
    const params = new HttpParams().set('searchTerm', searchTerm);
    return this.http.get<Producto[]>(`${this.myAppUrl}${this.myApiUrl}search`, { params });
  }
  
}
