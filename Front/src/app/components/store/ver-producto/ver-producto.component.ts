// ver-producto.component.ts

import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Producto } from 'src/app/interfaces/producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-ver-producto',
  templateUrl: './ver-producto.component.html',
  styleUrls: ['./ver-producto.component.css']
})
export class VerProductoComponent implements OnInit {
  @Input() id!: number; // Declare and mark as input
  loading: boolean = false;
  producto!: Producto;

  constructor(private _productoService: ProductoService, private aRoute: ActivatedRoute) {}

  ngOnInit() {
    this.obtenerPro();
  }

  obtenerPro() {
    this.loading = true;
    this._productoService.getProducto(this.id).subscribe(data => {
      console.log(data);
      this.producto = data;
      this.loading = false;
    });
  }
}
