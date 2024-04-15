import { Injectable } from '@angular/core';
import { Prodotto } from '../models/prodotto';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Risposta } from '../models/risposta';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProdottoService {

  base_url: string = "https://localhost:7108/Prodotto";

  constructor(private http: HttpClient) { }

  recuperaTuttiNonFiltrati() : Observable<Risposta> {
    return this.http.get<Risposta>(`${this.base_url}/nonfiltrati`);
  }

  eliminaProdotto(varCodice: string) : Observable<Risposta> {
    return this.http.delete<Risposta>(`${this.base_url}/elimina/${varCodice}`);
  }

  inserisciProdotto(objProd: Prodotto) : Observable<Risposta> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json')

    return this.http.post<Risposta>(`${this.base_url}/inserisci`, objProd, { headers: headerCustom })
  }

  recuperaProdotto(varCodice: string) : Observable<Risposta> {
    return this.http.get<Risposta>(`${this.base_url}/${varCodice}`);
  }

  modificaProdotto(objProd: Prodotto) : Observable<Risposta> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json')

    return this.http.put<Risposta>(`${this.base_url}/modifica/${objProd.cod}`, objProd, {headers: headerCustom});
  }
}
