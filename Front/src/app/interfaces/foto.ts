export interface Foto {
    id: number;
    nombreFo: string;
    data: string; // Cambia el tipo según lo que necesites para almacenar la imagen
    localId: number; // Asumiendo que localId es de tipo number
    productoId: string; // Asumiendo que productoId es de tipo number
  }