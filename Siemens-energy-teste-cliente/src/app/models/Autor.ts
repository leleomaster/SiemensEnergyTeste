import { Livro } from "./Livro";

export interface Autor {
    id: number;
    nome: string;
    livros: Livro[];
}