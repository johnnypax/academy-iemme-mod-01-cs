import { Component } from '@angular/core';
import { ProdottoService } from '../../services/prodotto.service';
import { Prodotto } from '../../models/prodotto';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrl: './lista.component.css'
})
export class ListaComponent {

  elenco: Prodotto[] = new Array();

  constructor(private service: ProdottoService){

  }

  stampa(): void {
    this.service.recuperaTuttiNonFiltrati().subscribe(risultato => {
      this.elenco = <Prodotto[]>risultato.data;
    })
  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    
    setInterval(() => {
      this.stampa();
    }, 1000)
   
  }

  elimina(varCodice: string | undefined): void {
    if(varCodice != undefined)
      this.service.eliminaProdotto(varCodice).subscribe(risultato => {
        if(risultato.status == "SUCCESS"){
          alert("STAPPOOOOO");
          this.stampa();
        }
        else
          alert("ERRORE" + <string>risultato.data);
      })
  }
}
