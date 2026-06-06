import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [FormsModule]
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private http: HttpClient, private router: Router) {}

  onLogin() {
    this.http.post<{token: string}>('/api/admin/Login', {
      username: this.username,
      password: this.password
    }).subscribe({
      next: (response) => {
        localStorage.setItem('jwt_token', response.token);
        this.router.navigate(['/admin']);
      },
      error: () => {
        alert('Usuario o contraseña incorrectos.');
      }
    });
  }
}
