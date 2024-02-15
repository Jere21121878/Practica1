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

const routes: Routes = [
  { path:'home', component: HomeComponent },

  { path:'login', component: LoginComponent },
  { path:'registro', component: RegistroComponent },
  { path:'vend/:userId', component: VendComponent },
  { path:'comp/:userId', component: CompComponent },

  
 { path: 'search', component: SearchResultComponent },

 { path:'comprarPro/:id', component: ComprarProductoComponent },

  { path:'store/:Id', component: VerStoreComponent },
  { path:'listPro/:storeId', component: ListProductosComponent },
  { path:'verPro/:id', component: VerProductoComponent },
  { path:'editarPro/:Id', component: AgregarEditarProductoComponent },

 



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
