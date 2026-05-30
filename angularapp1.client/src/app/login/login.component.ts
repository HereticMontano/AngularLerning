import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: false
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  onLogin() {
    // TODO: implementar la lógica de autenticación contra la API
    console.log('Login:', this.username, this.password);
  }
}
