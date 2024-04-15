import { Component, OnDestroy } from '@angular/core';
import { ProdottoService } from '../../services/prodotto.service';
import { Prodotto } from '../../models/prodotto';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrl: './lista.component.css'
})
export class ListaComponent implements OnDestroy {

  elenco: Prodotto[] = new Array();
  handleInterval: any;

  visualizzaModifica: boolean = false;

  private cod:	string | undefined;
  nom:	string | undefined;
  cat:	string | undefined;
  des:	string | undefined;
  pre:	number | undefined;
  qua:	number | undefined;

  constructor(private service: ProdottoService){

  }

  stampa(): void {
    this.service.recuperaTuttiNonFiltrati().subscribe(risultato => {
      this.elenco = <Prodotto[]>risultato.data;
    })
  }

  ngOnInit(): void {
    this.handleInterval = setInterval(() => {   //Associo l'handle dell'interval alla variabile (per il successivo clearinterval)
      this.stampa();
    }, 1000)
  }

  ngOnDestroy(): void {
    // console.log("Distrutto Lista Component")
    clearInterval(this.handleInterval);         //Eliminazione dell'interval tramite il suo handle
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

  apriModifica(varCodice: string | undefined): void {
    
    this.service.recuperaProdotto(<string>varCodice).subscribe(risultato => {
      if(risultato.status == "SUCCESS"){
        let prod = <Prodotto>risultato.data;

        this.cod = prod.cod;
        this.nom = prod.nom;
        this.cat = prod.cat;
        this.des = prod.des;
        this.pre = prod.pre;
        this.qua = prod.qua;
      }
    })

    this.visualizzaModifica = true;
  }

  salvaModifica(): void {
    let pro = new Prodotto();

    pro.cod = this.cod;
    pro.nom = this.nom;
    pro.cat = this.cat;
    pro.des = this.des;
    pro.pre = this.pre;
    pro.qua = this.qua;

    this.service.modificaProdotto(pro).subscribe(risultato => {
      if(risultato.status == "SUCCESS"){
        alert("STAPPOOOOO");
        this.stampa();
      }
      else
        alert("ERRORE" + <string>risultato.data);
    })

  }

  annullaMod(): void {
    this.visualizzaModifica = false;

    this.cod = undefined;
    this.nom = undefined;
    this.cat = undefined;
    this.des = undefined;
    this.pre = undefined;
    this.qua = undefined;
  }
}
