import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Producto } from 'src/app/interfaces/producto';
import { FotoService } from 'src/app/services/foto.service';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css']
})
export class SearchResultComponent implements OnInit {
  searchTerm: string = '';
  productos: Producto[] = [];
  productoIdSeleccionado: number | undefined;
  mostrarListaProductos: boolean = false;
  foto: string = '';

  constructor(
    private activatedRoute: ActivatedRoute,
    private productoService: ProductoService,
    private fotoService: FotoService ,// Inyectar el servicio de fotos

    private router: Router
  ) {

  }

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe((params: Params) => {
      this.searchTerm = params['term'] || '';
      this.getFilteredProductos();
    });
  }

  getFilteredProductos(): void {
    this.productoService.getProductosBySearchTerm(this.searchTerm).subscribe((productos) => {
      console.log('API Response:', productos); // Log the response to the console
      this.productos = productos;
      this.productos.forEach(producto => {
        if (producto.id) {
          this.getProductoFoto(producto.id.toString()); // Convertir el id a string antes de pasarlo
        }
      });
    });
  }

  verProducto(producto: Producto) {
    this.router.navigate(['/comprarPro', producto.id]);
  }

  getProductoFoto(productoId: string | null) {
    if (!productoId) return; 

    this.fotoService.getFotosByProductoId(productoId).subscribe((fotos) => {
      if (fotos && fotos.length > 0) {
        // Suponiendo que obtienes una sola foto por local, puedes tomar la primera foto del array
        this.foto = 'data:image/jpeg;base64,' + fotos[0].data;
      } else {
        // Si no hay fotos disponibles para el local, puedes asignar una imagen predeterminada o dejarla vacía
        this.foto = ''; // O asignar una imagen predeterminada aquí
      }
    });
  }
  
}