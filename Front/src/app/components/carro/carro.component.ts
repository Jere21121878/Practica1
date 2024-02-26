import { Component, OnInit, AfterViewInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { DetalleCompra } from 'src/app/interfaces/detalle-compra';
import { CompraService } from 'src/app/services/compra.service';
import { DetalleCompraService } from 'src/app/services/detalle-compra.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FotoService } from 'src/app/services/foto.service';
import { Foto } from 'src/app/interfaces/foto';
import { Compra } from 'src/app/interfaces/compra';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-carro',
  templateUrl: './carro.component.html',
  styleUrls: ['./carro.component.css']
})
export class CarroComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['imagen', 'nombreProducto', 'tienda', 'cantidadPro', 'subtotal', 'acciones'];
  dataSource = new MatTableDataSource<DetalleCompra>();
  loading: boolean = false;
  detalleCompraList: DetalleCompra[] = [];
  compradorId: string = '';
  fotos: { [key: string]: Foto[] } = {};
  totalAPagar: number = 0;
  constructor(
    private route: ActivatedRoute,
    private detalleCompraService: DetalleCompraService,
    private _snackBar: MatSnackBar,
    private authService: AuthenticationService,
    private fotoService: FotoService,
    private compraService: CompraService,
    private productoService: ProductoService,
  ) {}

  ngOnInit(): void {
    this.authService.isLoggedIn$.subscribe((loggedIn) => {
      if (loggedIn) {
        const userData = JSON.parse(localStorage.getItem('userData') ?? '');
        if (userData && userData.userId) {
          this.compradorId = userData.userId;
          this.obtenerDetalles();
        } else {
          console.error("No se encontró el ID del usuario en los datos del usuario almacenados en el localStorage.");
          // Aquí puedes manejar la situación en la que no se encuentra el ID del usuario
        }
      }
    });
  }
  
  obtenerDetalles() {
    this.authService.isLoggedIn$.subscribe((loggedIn) => {
        if (loggedIn) {
            const userData = JSON.parse(localStorage.getItem('userData') ?? '');
            this.compradorId = userData.userId ?? '';
            this.detalleCompraService.getDetalleVentaByCompradorId(this.compradorId).subscribe(response => {
                this.detalleCompraList = response.map(detalle => {
                    return {
                        ...detalle,
                        nombreProducto: detalle.producto?.nombrePro,
                        tienda: detalle.local?.nombreLo,
                        subtotal: detalle.precioUnitario * detalle.cantidad
                    };
                });

                // Obtener las fotos por productoId y asignarlas a cada detalle
                this.detalleCompraList.forEach(detalle => {
                    this.fotoService.getFotosByProductoId(detalle.productoId).subscribe(fotos => {
                        if (fotos && fotos.length > 0) {
                            detalle.foto = 'data:image/jpeg;base64,' + fotos[0].data;
                        }
                    });
                });

                this.dataSource.data = this.detalleCompraList;
            });
        }
    });
}

  
  eliminarDetalle(Id: number) {
    this.loading = true;
    this.detalleCompraService.deleteDetalleCompra(Id).subscribe(() => {
      this.mensajeExito();
      this.loading = false;
      this.obtenerDetalles();
    });
  }

  mensajeExito() {
    this._snackBar.open('Producto Eliminado Exitosamente', '', {
      duration: 1500,
      horizontalPosition: 'right'
    });
  }

  ngAfterViewInit() {}
  ejecutarCompra() {
    const detallesCompra = this.dataSource.data;
    const comprasPorLocalId: { [key: number]: DetalleCompra[] } = {};
  
    detallesCompra.forEach(detalle => {
      if (!(detalle.localId in comprasPorLocalId)) {
        comprasPorLocalId[detalle.localId] = [];
      }
      comprasPorLocalId[detalle.localId].push(detalle);
    });
  
    Object.values(comprasPorLocalId).forEach(detallesPorLocal => {
      const localId = detallesPorLocal[0].localId;
      const compra: Compra = {
        id: 0,
        total: detallesPorLocal.reduce((total, detalle) => total + detalle.subtotal, 0),
        fecha: new Date(),
        localId: localId,
        compradorId: this.compradorId,
        detalles: detallesPorLocal
      };
  
      // Realizar la solicitud POST para ejecutar la compra
      this.compraService.ejecutarCompra(compra).subscribe(() => {
        // Una vez que la compra se haya ejecutado con éxito, eliminar los detalles de compra
        detallesPorLocal.forEach(detalle => {
          if (detalle.id !== undefined) { // Verificar si el id es definido antes de llamar a eliminarDetalle()
            this.eliminarDetalle(detalle.id);
  
            // Restar la cantidad de detalleCompra a la cantidadPro del Producto
            this.productoService.getProducto(+detalle.productoId).subscribe(producto => {
              if (producto.id !== undefined) {
                producto.cantidadPro -= detalle.cantidad;
                this.productoService.updateProducto(producto.id, producto).subscribe(() => {
                  console.log('Cantidad actualizada para el producto:', producto.nombrePro);
                }, error => {
                  console.error('Error al actualizar la cantidad del producto:', error);
                });
              } else {
                console.error('El producto no tiene un ID definido.');
              }
            }, error => {
              console.error('Error al obtener el producto:', error);
            });
          }
        });
        // Recargar la página después de eliminar los detalles de compra
        window.location.reload();
        // Manejar la respuesta o realizar alguna lógica adicional
        // En este ejemplo, simplemente mostramos un mensaje de éxito
        this.mostrarMensajeExito();
      }, error => {
        console.error('Error al ejecutar la compra:', error);
        // Manejar errores
      });
    });
  }


  mostrarMensajeExito() {
    this._snackBar.open('Compra realizada con éxito', '', {
      duration: 2000,
      horizontalPosition: 'right'
    });
  }
  calcularTotal(): number {
    this.totalAPagar = this.dataSource.data.reduce((total, detalle) => total + detalle.subtotal, 0);
    return this.totalAPagar;
  }
}
