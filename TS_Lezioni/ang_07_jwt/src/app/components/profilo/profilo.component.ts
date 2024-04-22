import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProfiloService } from '../../services/profilo.service';

@Component({
  selector: 'app-profilo',
  templateUrl: './profilo.component.html',
  styleUrl: './profilo.component.css'
})
export class ProfiloComponent {

  datiUtente: string | undefined;

  constructor(private router: Router, private service: ProfiloService){
    if(!localStorage.getItem("ilToken"))
      router.navigateByUrl("/login")
  }

  ngOnInit(): void {

    this.service.recuperaProfilo().subscribe(risultato => {
      this.datiUtente = risultato.data
    })
    
  }
  

}
