import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { GeneroService } from '../../../services/genero.service';
import { Genero } from '../../../models/Genero';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-Generoes',
  templateUrl: './Genero.component.html',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  styleUrls: ['./Genero.component.css']
})
export class GeneroComponent implements OnInit {
  formGenero: FormGroup;
  generos: Genero[] | null = null;
  editando = false;
  generoeId: number | null = null;

  constructor(private service: GeneroService, private cdr: ChangeDetectorRef) {
    this.formGenero = new FormGroup({
      nome: new FormControl("", [
        Validators.required,
        Validators.minLength(3)
      ])
    })
  }

  ngOnInit() {
    this.carregarGeneros();
  }

  carregarGeneros() {
    this.service.obterTodos().subscribe(data => {
      
      this.generos = data
      this.cdr.detectChanges();
    });
  }

  salvar() {
    if (this.formGenero.valid) {
      if (this.editando) {
        this.service.atualizar(this.generoeId!, this.formGenero.value).subscribe(() => this.resetForm());
      } else {
        this.service.inserir(this.formGenero.value).subscribe(() => this.carregarGeneros());
      }
    }
  }

  editar(generoe: any) {
    this.editando = true;
    this.generoeId = generoe.id;
    this.formGenero.patchValue(generoe);
  }

  deletar(id: number) { this.service.deletar(id).subscribe(() => this.carregarGeneros()); }

  resetForm() {
    this.editando = false;
    this.formGenero.reset();
    this.carregarGeneros();
  }
}