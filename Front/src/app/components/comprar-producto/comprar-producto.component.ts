import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductoService } from 'src/app/services/producto.service';
import { LocalService } from 'src/app/services/local.service';
import { DetalleCompraService } from 'src/app/services/detalle-compra.service'; // Importa el servicio y la interfaz de DetalleCompra
import { CompraService } from 'src/app/services/compra.service';
import { DetalleCompra } from 'src/app/interfaces/detalle-compra';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-comprar-producto',
  templateUrl: './comprar-producto.component.html',
  styleUrls: ['./comprar-producto.component.css']
})
export class ComprarProductoComponent implements OnInit {
  Id!: number;
  localNombre: string = '';
  cantidadSeleccionada: number = 1;
  precioUnitario: number = 0;
  subtotal: number = 0;
  localId: number = -1; // Inicializar localId con un valor predeterminado
  showDropdown: boolean = false;

  constructor(
    private aRoute: ActivatedRoute,
    private productoService: ProductoService,
    private localService: LocalService,
    private router: Router,
    private _snackBar: MatSnackBar,

    private compraService: CompraService,
    private detalleCompraService: DetalleCompraService // Inyecta el servicio de DetalleCompraService
  ) {}

  ngOnInit() {
    this.Id = Number(this.aRoute.snapshot.paramMap.get('id'));
    this.productoService.getProducto(this.Id).subscribe(producto => {
      if (producto.localId) {
        this.localService.getLocal(producto.localId).subscribe(local => {
          this.localNombre = local.nombreLo;
          this.localId = local.id ?? -1;
        });
      }
      this.precioUnitario = producto.precioVendido;
    });
  }
  seleccionarCantidad(cantidad: number) {
    this.cantidadSeleccionada = cantidad;
    this.showDropdown = false; // Oculta la lista después de seleccionar un número
  }
  
  toggleDropdown() {
    this.showDropdown = !this.showDropdown;
  }

  agregarAlCarrito() {
    const userId = localStorage.getItem('userId');
    if (!userId) {
      console.error('El usuario no ha iniciado sesión.');
      return;
    }
  
    const detalleCompra: DetalleCompra = {
      productoId: this.Id.toString(), // Convertir this.Id a una cadena de texto
      cantidad: this.cantidadSeleccionada,
      precioUnitario: this.precioUnitario,
      localId: this.localId,
      compradorId: userId,
      subtotal: this.precioUnitario * this.cantidadSeleccionada
    };
  
    this.detalleCompraService.addDetalleCompra(detalleCompra).subscribe(
      response => {
        console.log('Producto agregado al carrito:', response);
        this.mensajeExito();
      },
      error => {
        console.error('Error al agregar producto al carrito:', error);
      }
    );
  }
  
  mensajeExito() {
    this._snackBar.open(`El producto fue añadido al carrito con éxito`,'', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }
  comprarProducto() {
    // Aquí podrías implementar la lógica para comprar el producto directamente en lugar de agregarlo al carrito
  }
}
