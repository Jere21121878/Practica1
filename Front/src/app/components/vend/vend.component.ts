import { Component } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';

export interface Tile {
  color: string;
  cols: number;
  rows: number;
  text: string;
}

@Component({
  selector: 'app-vend',
  templateUrl: './vend.component.html',
  styleUrls: ['./vend.component.css'],
  providers: [MatGridListModule]
})
export class VendComponent {
  tiles: Tile[] = [
    {text: 'Tus Tiendas', cols: 3, rows: 1, color: 'lightblue'},
    {text: 'Contabilidad', cols: 1, rows: 2, color: 'lightgreen'},
    {text: 'Stock Productos', cols: 1, rows: 1, color: 'lightpink'},
    {text: 'Reseñas de tus compradores', cols: 2, rows: 1, color: '#DDBDF1'},
  ];
}