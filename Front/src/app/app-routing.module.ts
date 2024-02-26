import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendComponent } from './components/vend/vend.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegistroComponent } from './components/registro/registro.component';
import { HomeComponent } from './components/home/home.component';
import { CompComponent } from './components/comp/comp.component';
import { VerStoreComponent } from './components/ver-store/ver-store.component';
import { ListProductosComponent } from './components/store/list-productos/list-productos.component';
import { VerProductoComponent } from './components/store/ver-producto/ver-producto.component';
import { AgregarEditarProductoComponent } from './components/store/agregar-editar-producto/agregar-editar-producto.component';
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

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },

  { path:'home', component: HomeComponent },

  { path:'login', component: LoginComponent },
  { path:'registro', component: RegistroComponent },
  { path:'vend/:userId', component: VendComponent },
  { path:'comp/:userId', component: CompComponent },

  
 { path: 'search', component: SearchResultComponent },
 { path: 'carro', component: CarroComponent },
 { path: 'contacto', component: ContactComponent },
 { path: 'sobre', component: SobreComponent },
 { path: 'seguridad', component:SeguridadComponent },
 { path: 'factura', component: FacturaComponent },
 { path: 'testimonios', component: TestimoniosComponent },

 { path:'comprarPro/:id', component: ComprarProductoComponent },

  { path:'store/:Id', component: VerStoreComponent },
  { path:'listPro/:storeId', component: ListProductosComponent },
  { path:'foto/:storeId', component: FotoComponent },

  { path:'verPro/:id', component: VerProductoComponent },
  { path:'editarPro/:Id', component: AgregarEditarProductoComponent },

 
  { path: '**', redirectTo: 'home', pathMatch: 'full' }



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
