import { Apoyo } from "./Apoyo/apoyo";

export class Persona {
    identificacion: string;
    nombre: string;
    apellido: string;
    sexo: string;
    edad: number;
    departamento: string;
    ciudad: string;
    apoyo : Apoyo = new Apoyo();
}
