import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { AutorService } from '../../../services/autor.service';
import { Autor } from '../../../models/Autor';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-Autores',
  templateUrl: './Autores.component.html',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  styleUrls: ['./Autores.component.css']
})
export class AutoresComponent implements OnInit {
  formAutor: FormGroup;
  autores: Autor[] | null = null;
  editando = false;
  autoreId: number | null = null;

  constructor(private service: AutorService, private cdr: ChangeDetectorRef) {
    this.formAutor = new FormGroup({
      nome: new FormControl("", [
        Validators.required,
        Validators.minLength(3)
      ])
    })
  }

  ngOnInit() {
    this.carregarAutors();
  }

  carregarAutors() {
    this.service.obterTodos().subscribe(data => {
      this.autores = data
      console.log(data)
      this.cdr.detectChanges();
    });
  }

  salvar() {
    if (this.formAutor.valid) {
      if (this.editando) {
        this.service.atualizar(this.autoreId!, this.formAutor.value).subscribe(() => this.resetForm());
      } else {
        this.service.inserir(this.formAutor.value).subscribe(() => this.carregarAutors());
      }
    }
  }

  editar(autore: any) {
    this.editando = true;
    this.autoreId = autore.id;
    this.formAutor.patchValue(autore);
  }

  deletar(id: number) { this.service.deletar(id).subscribe(() => this.carregarAutors()); }

  resetForm() {
    this.editando = false;
    this.formAutor.reset();
    this.carregarAutors();
  }
}