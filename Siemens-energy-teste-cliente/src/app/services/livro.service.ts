import { HttpClient, HttpErrorResponse, HttpResponse } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Livro } from "../models/Livro";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class LivroService {
    private API = 'https://localhost:7114/v1/Livro';
    private http = inject(HttpClient);

    obterTodos(): Observable<Livro[]> {
        return this.http.get<Livro[]>(`${this.API}/livros`);
    }

    obterPorId(id: number): Observable<HttpResponse<Livro>> {
        return this.http.get<Livro>(`${this.API}/${id}`, { observe: 'response' });
    }

    inserir(livro: any): Observable<HttpResponse<void>> {
        return this.http.post<void>(this.API, livro, { observe: 'response' });
    }

    atualizar(livro: Livro): Observable<HttpResponse<void>> {      
        return this.http.put<void>(`${this.API}`, livro, { observe: 'response' });
    }

    deletar(id: number|null): Observable<HttpResponse<void>> {
        return this.http.delete<void>(`${this.API}/${id}`, { observe: 'response' });
    }
}