import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonaService } from '../../services/persona.service';
import { Persona } from '../../models/persona';
import { Oggetto } from '../../models/oggetto';
import { OggettoService } from '../../services/oggetto.service';

@Component({
  selector: 'app-persona-detail',
  templateUrl: './persona-detail.component.html',
  styleUrl: './persona-detail.component.css'
})
export class PersonaDetailComponent {

  nominativo: string | undefined;
  codice: string | undefined;

  oggetto_nome: string | undefined;
  oggetto_descrizione: string | undefined;
  listaOggetti: Oggetto[] = new Array();

  constructor(
    private rottaAttiva: ActivatedRoute, 
    private servicePer: PersonaService,
    private serviceOgg: OggettoService,
    private router: Router
  ){

  }

  ngOnInit(): void {
    
    this.rottaAttiva.params.subscribe( parametri => {
      let identificativo = parametri['cd'];           //Dichiarato nel app-routing.module.ts

      let per = this.servicePer.GetById(identificativo);
      this.nominativo = per?.nominativo;
      this.codice = per?.codice;
      // this.listaOggetti = per?.listaOgg;

      if(this.codice != null)
        this.listaOggetti = this.serviceOgg.GetByCodiceProprietario(this.codice);
    })
  }

  modifica() {
    let per = new Persona();
    per.nominativo = this.nominativo;
    per.codice = this.codice;

    if(this.servicePer.Update(per)){
      console.log("STAPPOOOOO")
      this.router.navigateByUrl("persona/list");
    }
    else{
      console.log("ERRORE");
      
    }
  }

  salvaOggetto(){
    let ogg = new Oggetto();
    ogg.codice = "OGG-" + (new Date().getTime());
    ogg.nome = this.oggetto_nome;
    ogg.descrizione = this.oggetto_descrizione;
    ogg.proprietarioRIF = this.codice;

    if(this.serviceOgg.Insert(ogg)){
      if(this.codice != null)
        this.listaOggetti = this.serviceOgg.GetByCodiceProprietario(this.codice);
    }
    else
      console.log("ERRORE")

      
  }

}
