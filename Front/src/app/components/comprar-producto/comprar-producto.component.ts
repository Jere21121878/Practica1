// comprar-producto.component.ts

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductoService } from 'src/app/services/producto.service';
import { LocalService } from 'src/app/services/local.service';


@Component({
  selector: 'app-comprar-producto',
  templateUrl: './comprar-producto.component.html',
  styleUrls: ['./comprar-producto.component.css']
})
export class ComprarProductoComponent implements OnInit {
  Id!: number;
  localNombre: string = '';

  constructor(private aRoute: ActivatedRoute, private productoService: ProductoService, private localService: LocalService) {}

  ngOnInit() {
    this.Id = Number(this.aRoute.snapshot.paramMap.get('id'));

    // Obtener información de la tienda asociada al producto
    this.productoService.getProducto(this.Id).subscribe(producto => {
      if (producto.localId) {
        this.localService.getLocal(producto.localId).subscribe(local => {
          this.localNombre = local.nombreLo;
        });
      }
    });
  }
}
