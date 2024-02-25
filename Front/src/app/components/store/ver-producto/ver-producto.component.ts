import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Producto } from 'src/app/interfaces/producto';
import { ProductoService } from 'src/app/services/producto.service';
import { FotoService } from 'src/app/services/foto.service';

@Component({
  selector: 'app-ver-producto',
  templateUrl: './ver-producto.component.html',
  styleUrls: ['./ver-producto.component.css']
})
export class VerProductoComponent implements OnInit {
  @Input() id!: number;
  loading: boolean = false;
  producto?: Producto; // Aquí usamos ? para indicar que producto podría ser undefined
  foto: string = '';

  constructor(
    private _productoService: ProductoService, 
    private _fotoService: FotoService, 
    private aRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    // Suscribirse a los cambios en los parámetros de la ruta para obtener el id
    this.aRoute.params.subscribe(params => {
      this.id = params['id']; // Asegúrate de que 'id' coincide con el nombre del parámetro en tu ruta
      this.obtenerPro(); // Llama a obtenerPro() después de que tengamos el id disponible
    });
  }

  obtenerPro() {
    this.loading = true;
    this._productoService.getProducto(this.id).subscribe(data => {
      console.log(data);
      this.producto = data;
      this.loading = false;

      if (this.producto) { // Verificamos si producto no es undefined
        if (this.producto && this.producto.id) {
          this.getProductoFoto(this.producto.id);
        }
      }
    });
  }

  getProductoFoto(productoId: number) {
    this._fotoService.getFotosByProductoId(productoId.toString()).subscribe((fotos) => {
      if (fotos && fotos.length > 0) {
        this.foto = 'data:image/jpeg;base64,' + fotos[0].data;
      } else {
        this.foto = '';
      }
    });
  }
}
