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
        if (local.id !== undefined) {
          // Obtener la imagen de fondo del local por su ID
          this.localService.getLocal(local.id).subscribe(localData => {
            // Asignar la URL de la imagen al objeto Local
            local.foto = localData.foto;
          });
        }
      });
    });
  }
  
  verTienda(localId: number | undefined) {
    if (localId !== undefined) {
      this.localIdSeleccionada = localId;
      this.mostrarListaProductos = true;
      this.router.navigate(['/store', localId]);
    }
  }

 
}
