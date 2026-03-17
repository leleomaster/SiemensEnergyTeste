import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { LivroService } from '../../../services/livro.service';
import { Livro } from '../../../models/Livro';
import { CommonModule } from '@angular/common';
import { Genero } from '../../../models/Genero';
import { Autor } from '../../../models/Autor';
import { GeneroService } from '../../../services/genero.service';
import { AutorService } from '../../../services/autor.service';

@Component({
  selector: 'app-Livroes',
  templateUrl: './Livro.component.html',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  styleUrls: ['./Livro.component.css']
})
export class LivroComponent implements OnInit {
  formLivro: FormGroup;
  livros: Livro[] | null = null;
  editando = false;
  livroeId: number | null = null;
  generos: Genero[] = [];
  autores: Autor[] = [];

  constructor(
    private fb: FormBuilder,
    private serviceLivro: LivroService,
    private serviceGenero: GeneroService,
    private serviceAutor: AutorService,
    private cdr: ChangeDetectorRef) {
    this.formLivro = this.fb.group({
      titulo: ['', [Validators.required, Validators.minLength(3)]],
      autor: [null, Validators.required],  // Receberá o objeto Autor completo
      genero: [null, Validators.required] // Receberá o objeto Genero completo
    });
  }

  ngOnInit(): void {

    this.carregarLivros();
    this.serviceGenero.obterTodos().subscribe(data => this.generos = data);
    this.serviceAutor.obterTodos().subscribe(data => this.autores = data);
  }

  carregarLivros() {
    this.serviceLivro.obterTodos().subscribe(data => {
      this.livros = data
      this.cdr.detectChanges();
    });
  }

  salvar() {
    if (this.formLivro.valid) {
      const updateLivro: Livro = this.formLivro.value;

      const inserirLivro: Livro = {
        id: null,
        titulo: updateLivro.titulo,
        autorId: updateLivro.autor!.id,
        generoId: updateLivro.genero!.id,
        genero: null,
        autor: null
      };


      if (this.editando) {
        updateLivro.id = this.livroeId!
        this.serviceLivro.atualizar(updateLivro).subscribe(() => this.resetForm());
      } else {
        this.serviceLivro.inserir(inserirLivro).subscribe(() => this.carregarLivros());
      }
    }
  }

  editar(livroe: any) {
    this.editando = true;
    this.livroeId = livroe.id;
    this.formLivro.patchValue(livroe);
  }

  deletar(id: number | null) { this.serviceLivro.deletar(id).subscribe(() => this.carregarLivros()); }

  resetForm() {
    this.editando = false;
    this.formLivro.reset();
    this.carregarLivros();
  }
}