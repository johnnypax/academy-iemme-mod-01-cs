import { Injectable } from '@angular/core';
import { Prodotto } from '../models/prodotto';
import { HttpClient } from '@angular/common/http';
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
}
