import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/authentication/login/login.component';
import { SharedModule } from './shared/shared.module';
import { VendComponent } from './components/vend/vend.component';
import { CompComponent } from './components/comp/comp.component';
import { RegistroComponent } from './components/registro/registro.component';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { FormStoreComponent } from './components/form-store/form-store.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StoresListComponent } from './components/stores-list/stores-list.component';
import { VerStoreComponent } from './components/ver-store/ver-store.component';
import { ListProductosComponent } from './components/store/list-productos/list-productos.component';
import { AgregarEditarProductoComponent } from './components/store/agregar-editar-producto/agregar-editar-producto.component';
import { VerProductoComponent } from './components/store/ver-producto/ver-producto.component';

import {MatIconModule} from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatButtonModule} from '@angular/material/button';
import { AddProdictComponent } from './components/store/add-prodict/add-prodict.component';
import { SearchResultComponent } from './components/search-result/search-result.component';
import { ComprarProductoComponent } from './components/comprar-producto/comprar-producto.component';
import { FotoComponent } from './components/foto/foto.component';
import { CarroComponent } from './components/carro/carro.component';
import { ContactComponent } from './components/contact/contact.component';
import { SobreComponent } from './components/sobre/sobre.component';
import { SeguridadComponent } from './components/seguridad/seguridad.component';
import { FacturaComponent } from './components/factura/factura.component';
import { TestimoniosComponent } from './components/testimonios/testimonios.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    VendComponent,
    CompComponent,
    RegistroComponent,
    HomeComponent,
    NavbarComponent,
    FooterComponent,
    FormStoreComponent,
    StoresListComponent,
    VerStoreComponent,
    ListProductosComponent,
    AgregarEditarProductoComponent,
    VerProductoComponent,
    AddProdictComponent,
    SearchResultComponent,
    ComprarProductoComponent,
    FotoComponent,
    CarroComponent,
    NavbarComponent,
    ContactComponent,
    SobreComponent,
    SeguridadComponent,
    FacturaComponent,
    TestimoniosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatTooltipModule,
    MatButtonModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
