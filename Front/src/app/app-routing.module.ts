import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendComponent } from './components/vend/vend.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegistroComponent } from './components/registro/registro.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path:'home', component: HomeComponent },

  { path:'login', component: LoginComponent },
  { path:'registro', component: RegistroComponent },

  { path:'vend/:userId', component: VendComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
