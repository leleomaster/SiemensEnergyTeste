import { HttpClient, HttpErrorResponse, HttpResponse } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Autor } from "../models/Autor";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class AutorService {
    private API = 'https://localhost:7114/v1/Autor';
   constructor(private http: HttpClient) {}

    obterTodos(): Observable<Autor[]> {
        return this.http.get<Autor[]>(`${this.API}/autores`);
    }

    obterPorId(id: number): Observable<HttpResponse<Autor>> {
        return this.http.get<Autor>(`${this.API}/${id}`, { observe: 'response' });
    }

    inserir(autor: Autor): Observable<HttpResponse<void>> {
        return this.http.post<void>(this.API, autor, { observe: 'response' });
    }

    atualizar(id: number, autor: Autor): Observable<HttpResponse<void>> {
        autor.id = id
        return this.http.put<void>(`${this.API}`, autor, { observe: 'response' });
    }

    deletar(id: number): Observable<HttpResponse<void>> {
        return this.http.delete<void>(`${this.API}?id=${id}`, { observe: 'response' });
    }
}