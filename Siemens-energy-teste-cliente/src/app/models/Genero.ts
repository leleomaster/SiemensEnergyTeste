import { Livro } from "./Livro";

export interface Genero { 
    id: number; 
    nome: string; 
    livros: Livro[];
}