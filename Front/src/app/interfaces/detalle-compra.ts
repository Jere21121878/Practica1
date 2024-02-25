import { Local } from "./local";
import { Producto } from "./producto";

export interface DetalleCompra {
    id?: number; // Hacer el campo id opcional con el operador "?"
    productoId: string;
    cantidad: number;
    precioUnitario: number;
    localId: number; 
    compradorId: string; 
    subtotal: number; 
    producto?: Producto; // Agregar referencia al producto
    local?: Local; // Agregar referencia al local
    foto?: string; 
}
