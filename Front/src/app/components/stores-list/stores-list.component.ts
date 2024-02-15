import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Local } from 'src/app/interfaces/local';
import { LocalService } from 'src/app/services/local.service';

@Component({
  selector: 'app-stores-list',
  templateUrl: './stores-list.component.html',
  styleUrls: ['./stores-list.component.css']
})
export class StoresListComponent {
  localList: Local[] = [];
  id: string = '';
  mostrarListaProductos: boolean = false;
  localIdSeleccionada: number | undefined;

  constructor(
    private localService: LocalService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.route.params.subscribe(params => {
      this.id = params['userId'] ? params['userId'].toString() : '';
    });
  }

  ngOnInit(): void {
    this.obtenerTiendas();
  }
  obtenerTiendas() {
    this.localService.getlocalsByVendedorId(this.id).subscribe(response => {
      this.localList = response;
      // Llamada adicional para obtener la imagen de fondo para cada tienda
      this.localList.forEach(local => {
        if (local.id !== undefined) { // Verificar que local.id no sea undefined
          this.localService.obtenerImagenFondo(local.id).subscribe(imagenFondoUrl => {
            local.imagenFondoUrl = imagenFondoUrl;
          });
        }
      });
    });
  }
  
  
  verTienda(localId: number | undefined) {
    // Verificar que localId no sea undefined antes de mostrar la lista de productos
    if (localId !== undefined) {
      // Almacenar localId para mostrar el componente correspondiente
      this.localIdSeleccionada = localId;
      // Mostrar la lista de productos
      this.mostrarListaProductos = true;
      // Navegar a la ruta correspondiente (opcional, ya que parece que ya estás haciendo esto)
      this.router.navigate(['/store', localId]);
    }
  }
}
