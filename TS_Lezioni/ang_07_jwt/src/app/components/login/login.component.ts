import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  user: string = "giovanni";
  pass: string = "1234";

  constructor(private service: AuthService, private router: Router){

  }

  verifica():void {

    this.service.login(this.user, this.pass).subscribe(risultato => {
      if(risultato.token){
        localStorage.setItem("ilToken", risultato.token)
        this.router.navigateByUrl("/profilo");
      }
    })

  }

}
