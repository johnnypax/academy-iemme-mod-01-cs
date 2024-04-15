import { Component } from '@angular/core';
import { Prodotto } from '../../models/prodotto';
import { ProdottoService } from '../../services/prodotto.service';

@Component({
  selector: 'app-inserimento',
  templateUrl: './inserimento.component.html',
  styleUrl: './inserimento.component.css'
})
export class InserimentoComponent {

  nom:	string | undefined;
  cat:	string | undefined;
  des:	string | undefined;
  pre:	number | undefined;
  qua:	number | undefined;

  constructor(private service: ProdottoService){

  }

  salva(): void {
    let prodotto = new Prodotto();
    prodotto.nom = this.nom;
    prodotto.cat = this.cat;
    prodotto.des = this.des;
    prodotto.pre = this.pre;
    prodotto.qua = this.qua;

    this.service.inserisciProdotto(prodotto).subscribe(risultato => {
      if(risultato.status == "SUCCESS")
        alert("STAPPOOOOOO")
      else
        alert("ERRORE")
    })
  }

}
