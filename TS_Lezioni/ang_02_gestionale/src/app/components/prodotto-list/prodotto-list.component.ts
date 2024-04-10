import { Component } from '@angular/core';
import { Prodotto } from '../../models/prodotto';
import { ProdottoService } from '../../services/prodotto.service';

@Component({
  selector: 'app-prodotto-list',
  templateUrl: './prodotto-list.component.html',
  styleUrl: './prodotto-list.component.css'
})
export class ProdottoListComponent {

  listaprod : Prodotto[] = [];

  constructor(private service: ProdottoService){

  }

  ngOnInit(){
    // debugger;
    this.listaprod = this.service.recuperaProdotti();
  }

}
