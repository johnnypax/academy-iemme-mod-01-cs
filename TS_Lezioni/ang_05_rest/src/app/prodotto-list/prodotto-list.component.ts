import { Component } from '@angular/core';
import { ProdottoService } from '../services/prodotto.service';
import { Prodotto } from '../models/prodotto';

@Component({
  selector: 'app-prodotto-list',
  templateUrl: './prodotto-list.component.html',
  styleUrl: './prodotto-list.component.css'
})
export class ProdottoListComponent {

  elenco: Prodotto[] = new Array();

  constructor(private service: ProdottoService){

  }

  ngOnInit(): void {
    this.service.GetAllFiltrati().subscribe(risultato => {
      this.elenco = <Prodotto[]>risultato.data
      console.log(this.elenco)
    });
  }

}
