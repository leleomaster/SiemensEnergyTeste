import { Autor } from "./Autor";
import { Genero } from "./Genero";

export interface Livro {
  id: number | null;
  titulo: string;
  autor: Autor | null;
  genero: Genero | null;
  autorId: number | null;
  generoId: number | null;
}