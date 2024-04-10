import { Component } from '@angular/core';
import { Prodotto } from '../../models/prodotto';
import { ProdottoService } from '../../services/prodotto.service';

@Component({
  selector: 'app-prodotto-create',
  templateUrl: './prodotto-create.component.html',
  styleUrl: './prodotto-create.component.css'
})
export class ProdottoCreateComponent {

  codice: string | undefined;
  nome: string | undefined;
  descrizione: string | undefined;
  prezzo: number | undefined;

  constructor(private service: ProdottoService){

  }

  salvaProdotto(){
    
    let prod = new Prodotto(this.codice, this.nome, this.descrizione, this.prezzo);
    this.service.inserisciProdotto(prod);
    
  }

}
