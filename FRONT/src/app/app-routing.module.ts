import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './componentes/home/home.component';
import { ListagemComponent } from './componentes/listagem/listagem.component';
import { CadastroComponent } from './componentes/cadastro/cadastro.component';
const routes: Routes = [
  {
      path: "home",
      component: HomeComponent,
  },
  {
      path: "cadastro",
      component: CadastroComponent,
  },
  {
      path: "listagem",
      component: ListagemComponent,
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
