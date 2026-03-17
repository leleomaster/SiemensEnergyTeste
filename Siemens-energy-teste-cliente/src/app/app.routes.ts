import { Routes } from '@angular/router';
import { LivroComponent } from './Features/Livros/Livro/Livro.component';
import { GeneroComponent } from './Features/Generos/Genero/Genero.component';
import { AutoresComponent } from './Features/Autores/Autores/Autores.component';

export const routes: Routes = [
    { path: 'livro', component: LivroComponent },
    { path: 'genero', component: GeneroComponent },
    { path: 'autor', component: AutoresComponent },
];
