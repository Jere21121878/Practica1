import { Component, OnInit } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';



@Component({
  selector: 'app-vend',
  templateUrl: './vend.component.html',
  styleUrls: ['./vend.component.css'],
  providers: [MatGridListModule]
})
export class VendComponent implements OnInit {
  activeSection: string = '';
  mostrarAddStore = false;

  ngOnInit(): void {
    this.setActiveSection('Home'); //
  }

  setActiveSection(section: string): void {
    this.activeSection = section;
  }
}