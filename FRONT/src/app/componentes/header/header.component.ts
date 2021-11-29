import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
 
  constructor(private router: Router) {}
  Inicio():void{
    this.router.navigate(["home"]);
  }
  Listagem(): void {
        this.router.navigate(["listagem"]);
    };
  Cadastro(): void {
      this.router.navigate(["cadastro"]);
  };

}
