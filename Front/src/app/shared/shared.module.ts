import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; 
import {MatGridListModule} from '@angular/material/grid-list';

import { ChartistModule } from "ng-chartist";

@NgModule({
  declarations: [
   
  ],
  imports: [
    CommonModule,
   
    HttpClientModule,
    FormsModule,
    MatGridListModule,
    ChartistModule
  ],
  exports:[
  
    HttpClientModule,
    FormsModule,
    MatGridListModule,
    ChartistModule
  ]
})
export class SharedModule { }
