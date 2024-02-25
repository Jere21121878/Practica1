import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Local } from 'src/app/interfaces/local';
import { LocalService } from 'src/app/services/local.service';
import { FotoService } from 'src/app/services/foto.service'; // Importar el servicio de fotos

@Component({
  selector: 'app-ver-store',
  templateUrl: './ver-store.component.html',
  styleUrls: ['./ver-store.component.css']
})
export class VerStoreComponent implements OnInit {
  local: Local | null = null;
  foto: string = '';

  constructor(
    private route: ActivatedRoute,
    private localService: LocalService,
    private fotoService: FotoService // Inyectar el servicio de fotos
  ) {}

  ngOnInit(): void {
    const localId = this.route.snapshot.paramMap.get('Id');
    this.localService.getLocal(parseInt(localId || '0')).subscribe((response) => {
      this.local = response; 
      this.getLocalFoto(localId);
    });
  }

  getLocalFoto(localId: string | null) {
    if (!localId) return; 

    this.fotoService.getFotosByLocalId(localId).subscribe((fotos) => {
      if (fotos && fotos.length > 0) {
        // Suponiendo que obtienes una sola foto por local, puedes tomar la primera foto del array
        this.foto = 'data:image/jpeg;base64,' + fotos[0].data;
      } else {
        // Si no hay fotos disponibles para el local, puedes asignar una imagen predeterminada o dejarla vacía
        this.foto = ''; // O asignar una imagen predeterminada aquí
      }
    });
  }
}
