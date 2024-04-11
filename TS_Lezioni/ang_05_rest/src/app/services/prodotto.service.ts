import { Injectable } from '@angular/core';
import { Prodotto } from '../models/prodotto';
import { HttpClient } from '@angular/common/http';
import { Status } from '../models/status';

@Injectable({
  providedIn: 'root'
})
export class ProdottoService {

  endpoint: string = "https://localhost:7108/Prodotto"

  constructor(private http: HttpClient) { }

  GetAllFiltrati(){
  //   fetch(`${this.endpoint}/filtrati`)
  //     .then(result => result.json())
  //     .then(contenuto => {
  //       console.log(contenuto.data)
  //       return contenuto.data;
  //     })
  //     .catch(errore => {
  //       console.log(errore)
  //     }).
  //     finally(() => {
  //       return [];
  //     })

    return this.http.get<Status>(`${this.endpoint}/filtrati`)

  }


}
