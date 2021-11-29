import { Component, OnInit } from "@angular/core";
import { Livros } from "src/app/models/livros";
import { LivrosService } from "src/app/services/livros.service";
import { Router } from '@angular/router';

@Component({
    selector: "app-listagem",
    templateUrl: "./listagem.component.html",
    styleUrls: ["./listagem.component.css"],
})
export class ListagemComponent implements OnInit {
    livros: Livros[] = [];
    colunasExibidas: String[] = [
        "id",
        "nome",
        "author",
        "editor",
        "categoria",
    ];

    constructor(private service: LivrosService, private router : Router) {}
    Cadastro(): void {
        this.router.navigate(["cadastro"]);
        };
    ngOnInit(): void {
        this.service.list().subscribe((Livros) => {
            this.livros = Livros;
        });
    }
}
