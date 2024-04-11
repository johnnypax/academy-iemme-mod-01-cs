import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonaInsertComponent } from './components/persona-insert/persona-insert.component';
import { FormsModule } from '@angular/forms';
import { PersonaListComponent } from './components/persona-list/persona-list.component';
import { PersonaDetailComponent } from './components/persona-detail/persona-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonaInsertComponent,
    PersonaListComponent,
    PersonaDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
