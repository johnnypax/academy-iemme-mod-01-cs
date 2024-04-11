import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonaService } from '../../services/persona.service';
import { Persona } from '../../models/persona';
import { Oggetto } from '../../models/oggetto';

@Component({
  selector: 'app-persona-detail',
  templateUrl: './persona-detail.component.html',
  styleUrl: './persona-detail.component.css'
})
export class PersonaDetailComponent {

  nominativo: string | undefined;
  codice: string | undefined;
  listaOggetti : Oggetto[] | undefined;

  constructor(
    private rottaAttiva: ActivatedRoute, 
    private service: PersonaService,
    private router: Router
  ){

  }

  ngOnInit(): void {
    
    this.rottaAttiva.params.subscribe( parametri => {
      let identificativo = parametri['cd'];           //Dichiarato nel app-routing.module.ts

      let per = this.service.GetById(identificativo);
      this.nominativo = per?.nominativo;
      this.codice = per?.codice;
      this.listaOggetti = per?.listaOgg;

    })
  }

  modifica() {
    let per = new Persona();
    per.nominativo = this.nominativo;
    per.codice = this.codice;

    if(this.service.Update(per)){
      console.log("STAPPOOOOO")
      this.router.navigateByUrl("persona/list");
    }
    else{
      console.log("ERRORE");
      
    }
  }

}
