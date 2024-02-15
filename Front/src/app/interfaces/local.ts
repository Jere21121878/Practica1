export interface Local {
    id?:number,
    nombreLo: string;
    direccionLo: string;
    descripcionLo: string;
    vendedorid?:string,
    categoria: string;
    horario: string;
    telefono: string;
    imagenFondoUrl: string | null; // Cambiado a string | null
}
