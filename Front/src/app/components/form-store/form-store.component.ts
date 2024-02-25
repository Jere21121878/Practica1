import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { LocalService } from 'src/app/services/local.service';

@Component({
  selector: 'app-form-store',
  templateUrl: './form-store.component.html',
  styleUrls: ['./form-store.component.css']
})
export class FormStoreComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup;
  Id: number;
  operacion: string='Agregar';
  vendedorId: string; // Agrega esta línea

  constructor(
    private fb: FormBuilder,
    private _localService: LocalService,
    private router: Router,
    private aRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
  ) {
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
      direccion: ['', Validators.required],
      telefono: ['', Validators.required],
      horario: ['', Validators.required],
      categoria: ['', Validators.required],
      imagenFondoUrl:['', Validators.required]// Cambiado a string | null

    });

    // Obtén el vendedorId del parámetro de la URL
    this.vendedorId = this.aRoute.snapshot.paramMap.get('userId') ?? '';

    // Convierte el id de la URL a número si es necesario
    this.Id = Number(this.aRoute.snapshot.paramMap.get('Id'));
  }

  ngOnInit(): void {
    if (this.Id != 0) {
      this.operacion = 'Editar';
      this.obtenerLocal(this.Id);
    }
  }

  obtenerLocal(Id: number) {
    this.loading = true;
    this._localService.getLocal(Id).subscribe(data => {
      this.form.setValue({
        nombre: data.nombreLo,
        descripcion: data.descripcionLo,
        direccion: data.direccionLo,
        categoria: data.categoria,
        horario: data.horario,
        telefono: data.telefono,
        imagenFondoUrl:data.foto
      });
      this.loading = false;
    });
  }

  agregarEditarLocal() {
    if (this.vendedorId) {
      const local: Local = {
        nombreLo: this.form.value.nombre,
        descripcionLo: this.form.value.descripcion,
        direccionLo: this.form.value.direccion,
        horario: this.form.value.horario,
        telefono: this.form.value.telefono,
        categoria: this.form.value.categoria,
        vendedorid: this.vendedorId,
        foto: this.form.value.foto, // Acceder al valor desde el formulario
      };
  
      if (this.Id != 0) {
        local.id = this.Id;
        this.editarLocal(this.Id, local);
      } else {
        this.agregarLocal(local);
      }
    } else {
      console.error('VendedorId es nulo o indefinido');
    }
  }

  editarLocal(Id: number, local: Local) {
    this.loading = true;
    this._localService.updateLocal(Id, local).subscribe(() => {
      this.loading = false;
      console.log('llegue')
      this.mensajeExito('actualizado');
      this.router.navigate(['/']);
    })
  }
  
  agregarLocal(local:Local) {
    this._localService.addLocal(local).subscribe(data => {
      this.mensajeExito('registrado');
      this.router.navigate(['']);
    })
  }

  mensajeExito(texto: string) {
    this._snackBar.open(`La tienda fue ${texto} con éxito`,'', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}

export interface Local {
    id?:number,
    nombreLo: string;
    direccionLo: string;
    descripcionLo: string;
    vendedorid?:string,
    categoria: string;
    horario: string;
    telefono: string;
    foto:string;

}
