import { Component } from '@angular/core';
import { RegistrationModel } from 'src/app/interfaces/registration-model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent {
  model: RegistrationModel = {
    email: '',
    password: '',
    name:'',
    apellido: '',
    direccion: '',
    provincia: '',
    localidad: '',
    celular: '',
    cp: '',
    rol: ''

  };
  constructor(private authService: AuthenticationService) { }

  register() {
    this.authService.register(this.model)
      .subscribe(
        (response: any) => {
          console.log(response);
        },
        (error: any) => {
          console.log(error);
        }
      );
  }
}
