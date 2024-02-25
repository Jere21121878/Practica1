import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-add-prodict',
  templateUrl: './add-prodict.component.html',
  styleUrls: ['./add-prodict.component.css']
})
export class AddProdictComponent implements OnInit{
  loading: boolean = false;
  form: FormGroup;
  operacion: string='Agregar';
  @Input() localId: number = 0;
  constructor(
    private fb: FormBuilder,
    private _productoService: ProductoService,
    private router: Router,
    private aRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
  ) {
    this.form = this.fb.group({
      nombrePro: ['', Validators.required],
      descripcionPro: ['', Validators.required],
      categoriaP: ['', Validators.required],
      foto: ['', Validators.required],
      precioVendido: ['', Validators.required],
      cantidadPro: ['', Validators.required],
    });
// Asignar localid solo si storeId está presente y no es nulo
const storeIdParam = this.aRoute.snapshot.paramMap.get('storeId');
if (storeIdParam) {
  this.localId = +storeIdParam;
}
  }

  ngOnInit(): void {
    // Set the default value of Id to 0
    
  }
  


  
  agregarEditarProducto() {
    // Asignar localid solo si storeId está presente y no es nulo
    const storeIdParam = this.aRoute.snapshot.paramMap.get('storeId');
    if (storeIdParam) {
      this.localId = +storeIdParam;
    }

    const producto: Producto = {
      nombrePro: this.form.value.nombrePro,
      descripcionPro: this.form.value.descripcionPro,
      categoriaP: this.form.value.categoriaP,
      cantidadPro: this.form.value.cantidadPro,
      precioVendido: this.form.value.precioVendido,
      precioComprado: this.form.value.precioComprado,

      foto: this.form.value.foto,
      localId: this.localId,
    };

    this.agregarPro(producto);
  }

 
  agregarPro(producto: Producto) {
    this._productoService.addProducto(producto).subscribe(data => {
      this.mensajeExito('registrado');
      this.router.navigate(['']);
    });
  }

  mensajeExito(texto: string) {
    this._snackBar.open(`El producto fue ${texto} con éxito`,'', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}

export interface Producto {
    id?:number,
    nombrePro: string;
    categoriaP: string;
    descripcionPro: string;
    localId:number,
    cantidadPro: string;
    precioVendido: number;
    precioComprado: number;

    foto: string;
}
