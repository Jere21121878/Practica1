import { DetalleCompra } from "./detalle-compra";

export interface Compra {
    id: number;
    total: number;
    fecha:Date;
    localId: number; 
    compradorId: string; 
    detalles: DetalleCompra[];
}
