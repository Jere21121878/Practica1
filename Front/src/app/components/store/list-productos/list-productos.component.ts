import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';

import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Producto } from 'src/app/interfaces/producto';
import { ProductoService } from 'src/app/services/producto.service';
import { AgregarEditarProductoComponent } from '../agregar-editar-producto/agregar-editar-producto.component';

@Component({
  selector: 'app-list-productos',
  templateUrl: './list-productos.component.html',
  styleUrls: ['./list-productos.component.css']
})
export class ListProductosComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['nombrePro', 'categoriaP', 'precio','cantidadPro','acciones'];
  dataSource = new MatTableDataSource<Producto>();
  loading: boolean = false;
  @ViewChild(AgregarEditarProductoComponent) agregarEditarProductoComponent!: AgregarEditarProductoComponent;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  productoList: Producto[] = [];
  Id: string = '';
  mostrarAddProdict: boolean = false;

//   role: string = '';
//   mostrarBotonAgregar: boolean = true;
  
  constructor(
      private _snackBar: MatSnackBar,
      private _productoService: ProductoService,
      private route: ActivatedRoute,
      private router: Router,
  
  
  ) {
      this.route.params.subscribe(params => {
          this.Id = params['Id'].toString();
      });
  }
  
  ngOnInit(): void {
   
        this.obtenerProductos();
      
  
      }
      mostrarAgregarProducto() {
        this.mostrarAddProdict = true;
      }
     
  ngAfterViewInit() {
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      if (this.dataSource.data.length > 0 && this.paginator._intl) {
          this.paginator._intl.itemsPerPageLabel = 'Items por pagina'
      }
  }
  
  obtenerProductos() {
      this._productoService.getProductosByLocalId(this.Id).subscribe(response => {
          this.productoList = response;
          this.dataSource.data = this.productoList;
  
     
      });
  }
  
  applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  
  eliminarProducto(Id: number) {
      this.loading = true;
      this._productoService.deleteProducto(Id).subscribe(() => {
          this.mensajeExito();
          this.loading = false;
          this.obtenerProductos();
      });
  }
  
  mensajeExito() {
      this._snackBar.open('Producto Eliminado Exitosamente', '', {
          duration: 1500,
          horizontalPosition: 'right'
      });
  }
  
  verFichaPro(Id: number) {
      this.router.navigate(['/verPro/', Id]);
    }
 
  }