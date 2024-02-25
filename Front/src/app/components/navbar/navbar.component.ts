import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { DetalleCompraService } from 'src/app/services/detalle-compra.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isLoggedIn: boolean = false;
  userData: any;
  userName: string = '';
  contadorProductos: number = 0;
  searchTerm: string = '';
  isDropdownOpen: boolean = false;

  constructor(
    private router: Router,
    private authService: AuthenticationService,
    private detalleCompraService: DetalleCompraService
  ) {}

  ngOnInit(): void {
    this.authService.isLoggedIn$.subscribe((isLoggedIn) => {
      this.isLoggedIn = isLoggedIn;
      if (isLoggedIn) {
        const userDataString = localStorage.getItem('userData');
        if (userDataString) {
          this.userData = JSON.parse(userDataString);
          this.userName = this.userData.nombre;
          
          // Obtener la cantidad de detalles de compra para el usuario actual
          this.detalleCompraService.getCantidadDetalleCompraPorUsuario(this.userData.userId)
            .subscribe(count => {
              this.contadorProductos = count;
            });
        }
      }
    });
  }

  search(): void {
    this.router.navigate(['/search'], { queryParams: { term: this.searchTerm } });
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
  toggleDropdown(): void {
    this.isDropdownOpen = !this.isDropdownOpen;
}
}
