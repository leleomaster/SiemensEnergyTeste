import { HttpClient, HttpErrorResponse, HttpResponse } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Genero } from "../models/Genero";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class GeneroService {
    private API = 'https://localhost:7114/v1/genero';
    private http = inject(HttpClient);

    obterTodos(): Observable<Genero[]> {
        return this.http.get<Genero[]>(`${this.API}/generos`);
    }

    obterPorId(id: number): Observable<HttpResponse<Genero>> {
        return this.http.get<Genero>(`${this.API}/${id}`, { observe: 'response' });
    }

    inserir(genero: Genero): Observable<HttpResponse<void>> {
        return this.http.post<void>(this.API, genero, { observe: 'response' });
    }

    atualizar(id: number, genero: Genero): Observable<HttpResponse<void>> {
         genero.id = id
        return this.http.put<void>(`${this.API}`, genero, { observe: 'response' });
    }

    deletar(id: number): Observable<HttpResponse<void>> {
        return this.http.delete<void>(`${this.API}/${id}`, { observe: 'response' });
    }
}