import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Producto } from 'src/app/interfaces/producto';
import { Foto } from 'src/app/interfaces/foto'; // Importa la interfaz Foto
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
  fotosPorProducto: { [key: string]: string } = {}; // Objeto para almacenar las fotos de los productos

  constructor(
    private activatedRoute: ActivatedRoute,
    private productoService: ProductoService,
    private fotoService: FotoService,
    private router: Router
  ) {}

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
        if (producto.id !== undefined) { // Verifica si producto.id está definido
          this.getProductoFoto(producto.id.toString()); // Convertir el id a string antes de pasarlo
        }
      });
    });
  }
  

  verProducto(producto: Producto) {
    this.router.navigate(['/comprarPro', producto.id]);
  }

  getProductoFoto(productoId: string) {
    this.fotoService.getFotosByProductoId(productoId).subscribe((fotos: Foto[]) => {
      if (fotos && fotos.length > 0) {
        // Almacena la primera foto de cada producto en el objeto fotosPorProducto
        this.fotosPorProducto[productoId] = 'data:image/jpeg;base64,' + fotos[0].data;
      } else {
        // Si no hay fotos disponibles, asigna una imagen predeterminada o deja vacío
        this.fotosPorProducto[productoId] = ''; // O asigna una imagen predeterminada aquí
      }
    });
  }
}
