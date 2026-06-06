import { Component, OnInit, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RouterModule, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

interface GalleryNameModel {
  id: string;
  title: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: true,
  styleUrl: './app.css',
  imports: [RouterModule, CommonModule]
})
export class App implements OnInit {
  protected readonly title = signal('angularapp1.client');
  public galleries = signal<GalleryNameModel[]>([]);

  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit() {
    this.http.get<GalleryNameModel[]>('/picture/GetGalleriesNames').subscribe({
      next: (result) => {
        this.galleries.set(result);
        
        // Redirigir a la primera galería si el usuario entra a la ruta base ("/")
        if (result.length > 0 && this.router.url === '/') {
          this.router.navigate(['/gallery', result[0].id]);
        }
      },
      error: (err) => {
        console.error('Error fetching galleries names', err);
      }
    });
  }
}
