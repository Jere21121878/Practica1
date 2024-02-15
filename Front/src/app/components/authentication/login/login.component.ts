import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/interfaces/login-model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  model: LoginModel = {
    email: '',
    password: ''
  };

  constructor(private authService: AuthenticationService, private router: Router) {}

  login() {
    this.authService.login(this.model).subscribe(
      response => {
        console.log(response);
        if (response.role === 'Vendedor') {
          this.authService.vendedorId = response.userId;
          this.router.navigate(['vend', response.userId]);
        } else if (response.role === 'Comprador') {
          this.router.navigate(['comp', response.userId]);
        }
      },
      error => {
        console.log(error);
      }
    );
  }
}
