import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Livros } from "../models/livros";

@Injectable({
    providedIn: "root",
})
export class LivrosService {
    private baseUrl = "http://localhost:5000/api/books";

    constructor(private http: HttpClient) {}

    list(): Observable<Livros[]> {
        return this.http.get<Livros[]>(`${this.baseUrl}/list`);
    }
    create(Livros: Livros): Observable<Livros> {
        return this.http.post<Livros>(`${this.baseUrl}/create`, Livros);
    }
}
