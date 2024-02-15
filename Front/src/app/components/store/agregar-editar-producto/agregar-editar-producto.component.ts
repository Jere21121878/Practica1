import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { Producto } from 'src/app/interfaces/producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-agregar-editar-producto',
  templateUrl: './agregar-editar-producto.component.html',
  styleUrls: ['./agregar-editar-producto.component.css']
})
export class AgregarEditarProductoComponent implements OnInit{
  loading: boolean = false;
  form: FormGroup;
  Id: number;

  operacion: string='Agregar';


  constructor(private fb: FormBuilder,private  _productoService: ProductoService,private router:Router,private aRoute:ActivatedRoute,
    private _snackBar: MatSnackBar){
    this.form = this.fb.group({
      localid: ['', Validators.required],
      nombrePro: ['', Validators.required],
      precio: ['', Validators.required],
      descripcionPro: ['', Validators.required],
      categoriaP: ['', Validators.required],
      imagen: ['', Validators.required],
      cantidadPro: ['', Validators.required],

  })
  this.Id=Number(this.aRoute.snapshot.paramMap.get('Id'));


}
  ngOnInit(): void {



    if(this.Id != 0) {
      this.operacion = 'Editar';
      this.obtenerPro(this.Id)
    }

      }



 obtenerPro(Id:number){
        this.loading = true;
    this._productoService.getProducto(Id).subscribe(data => {
      this.form.setValue({
        nombrePro: data.nombrePro,
        descripcionPro: data.descripcionPro,
        categoriaP: data.categoriaP,
        cantidadPro: data.cantidadPro,
        imagen: data.imagen,
        precio: data.precio,
        localid: data.precio,




      })
      this.loading = false;
    })
      }


      agregarEditarPro() {
        
        const producto: Producto = {
          localId: this.form.value.precio,  // Corrected from precio to localid
      
          nombrePro: this.form.value.nombrePro,
          descripcionPro: this.form.value.descripcionPro,
          categoriaP: this.form.value.categoriaP,
          cantidadPro: this.form.value.cantidadPro,
          imagen: this.form.value.imagen,
          precio: this.form.value.precio,
        }
      
        if (this.Id != 0) {
          producto.id = this.Id;
          this.editarPro(this.Id, producto);
        } else {
          this.agregarPro(producto);
        }
      }
      editarPro(Id: number, producto: Producto) {
        console.log('Product to update:', producto); // Add this line
        this.loading = true;
        this._productoService.updateProducto(Id, producto).subscribe(() => {
          this.loading = false;
          console.log('llegue')
          this.mensajeExito('actualizado');
          this.router.navigate(['/listPro']);
        });
      }
      
    agregarPro(producto:Producto) {
      this._productoService.addProducto(producto).subscribe(data => {
        this.mensajeExito('registrado');
        this.router.navigate(['/listPro']);

      
  } )
 }
  mensajeExito(texto: string) {
    this._snackBar.open(`El producto fue ${texto} con exito`,'', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }




}
