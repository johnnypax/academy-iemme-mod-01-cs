import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ang_06_ferramenta';

  visualizzaLista: boolean = true;

  visLista(): void {
    this.visualizzaLista = true;
  }

  visInserimento(): void {
    this.visualizzaLista = false;
  }
}
