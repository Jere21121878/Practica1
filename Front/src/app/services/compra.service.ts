import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Compra } from '../interfaces/compra';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/enviroments/environment.development';
import { DetalleCompra } from '../interfaces/detalle-compra';

@Injectable({
  providedIn: 'root'
})
export class CompraService {

  private myAppUrl: string = environment.Url;
  private myApiUrl: string = 'api/Compra/';

  constructor(private http: HttpClient) { }


  
  getDetalleCompra(Id: number): Observable<DetalleCompra[]> {
    return this.http.get<DetalleCompra[]>(`${this.myAppUrl}${this.myApiUrl}${Id}/detalles`);
  }
  

  agregarAlCarrito(detallesCompra: DetalleCompra[]): Observable<void> {
    return this.http.post<void>(`${this.myAppUrl}${this.myApiUrl}agregar-al-carrito`, detallesCompra);
  }
  ejecutarCompra(compra: Compra): Observable<void> {
    return this.http.post<void>(`${this.myAppUrl}${this.myApiUrl}compra`, compra);
  }

  getComprasByLocalId(localId: string): Observable<Compra[]> {
    console.log('URL:', `${this.myAppUrl}${this.myApiUrl}local/${localId}`);
    return this.http.get<Compra[]>(`${this.myAppUrl}${this.myApiUrl}local/${localId}`);
  }
  getComprasByCompradorId(localId: string): Observable<Compra[]> {
    console.log('URL:', `${this.myAppUrl}${this.myApiUrl}local/${localId}`);
    return this.http.get<Compra[]>(`${this.myAppUrl}${this.myApiUrl}local/${localId}`);
  }

}
