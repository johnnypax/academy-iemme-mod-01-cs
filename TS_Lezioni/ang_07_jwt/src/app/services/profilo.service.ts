import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Risposta } from '../models/risposta';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfiloService {

  constructor(private http: HttpClient) { }

  recuperaProfilo(): Observable<Risposta>{
    let contenutoToken = localStorage.getItem("ilToken");

    let headerCustom = new HttpHeaders(
      {
        Authorization: `Bearer ${contenutoToken}`
      }
    );

    return this.http.get<Risposta>("https://localhost:7233/Home/adminprofilo", {headers: headerCustom});
  }
}
