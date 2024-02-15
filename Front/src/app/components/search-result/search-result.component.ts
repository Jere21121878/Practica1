import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Producto } from 'src/app/interfaces/producto';
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

  constructor(
    private activatedRoute: ActivatedRoute,
    private productoService: ProductoService,
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
    });
  }

  verProducto(producto: Producto) {
    this.router.navigate(['/comprarPro', producto.id]);
  }
  
}