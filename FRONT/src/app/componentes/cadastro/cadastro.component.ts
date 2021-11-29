import { Livros } from './../../models/livros';
import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { LivrosService } from 'src/app/services/livros.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
  //nome!: string;
  //descricao!: string;
  //quantidade!: number;
  //preco!: number;
  //categoriaId!: number;

  constructor(
      private router: Router,
      private livroService: LivrosService,
  ) {}
  
  ngOnInit(): void {}

  cadastrar(): void {
    let Livros: Livros = {
        nome: this.nome,
        descricao: this.descricao,
        preco: this.preco,
        quantidade: this.quantidade,
    };
    this.produtoService.create(Livros).subscribe((livros) => {
        console.log(livros);
        this.router.navigate(["produto/listar"]);
    });
}
}
