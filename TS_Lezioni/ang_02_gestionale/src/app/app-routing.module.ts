import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProdottoListComponent } from './components/prodotto-list/prodotto-list.component';
import { ProdottoCreateComponent } from './components/prodotto-create/prodotto-create.component';

const routes: Routes = [
  {path: "", redirectTo: "prodotto/lista", pathMatch: "full"},
  {path: "prodotto/lista", component: ProdottoListComponent},
  {path: "prodotto/inserisci", component: ProdottoCreateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
