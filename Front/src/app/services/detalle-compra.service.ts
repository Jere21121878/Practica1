import { Injectable } from '@angular/core';
import { DetalleCompra } from '../interfaces/detalle-compra';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class DetalleCompraService {
  private myAppUrl: string = environment.Url;
  private myApiUrl: string = 'api/DetalleCompra/';

  constructor(private http: HttpClient) { }

  getDetalleCompra(Id: number): Observable<DetalleCompra> {
    return this.http.get<DetalleCompra>(`${this.myAppUrl}${this.myApiUrl}${Id}`);
  }

  deleteDetalleCompra(Id: number): Observable<void> {
    return this.http.delete<void>(`${this.myAppUrl}${this.myApiUrl}${Id}`);
  }

  addDetalleCompra(detalleCompra: DetalleCompra): Observable<DetalleCompra> {
    return this.http.post<DetalleCompra>(`${this.myAppUrl}${this.myApiUrl}`, detalleCompra);
  }

  updateDetalleCompra(Id: number, detalleCompra: DetalleCompra): Observable<void> {
    return this.http.put<void>(`${this.myAppUrl}${this.myApiUrl}${Id}`, detalleCompra);
  }
  getDetalleVentaByCompradorId(compradorId: string): Observable<DetalleCompra[]> {
    console.log('URL:', `${this.myAppUrl}${this.myApiUrl}comprador/${compradorId}`);
    return this.http.get<DetalleCompra[]>(`${this.myAppUrl}${this.myApiUrl}comprador/${compradorId}`);
  }
  getCantidadDetalleCompraPorUsuario(userId: string): Observable<number> {
    return this.http.get<number>(`${this.myAppUrl}${this.myApiUrl}count/${userId}`);
  }
}
