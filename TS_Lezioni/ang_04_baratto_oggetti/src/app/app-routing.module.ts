import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonaInsertComponent } from './components/persona-insert/persona-insert.component';
import { PersonaListComponent } from './components/persona-list/persona-list.component';
import { PersonaDetailComponent } from './components/persona-detail/persona-detail.component';

const routes: Routes = [
  {path: "", redirectTo:"persona/list", pathMatch:"full"},
  {path: "persona/detail/:cd", component: PersonaDetailComponent},
  {path: "persona/insert", component: PersonaInsertComponent},
  {path: "persona/list", component: PersonaListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
