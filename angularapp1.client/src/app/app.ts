import { Component, OnInit, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RouterModule } from '@angular/router';
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

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<GalleryNameModel[]>('/picture/GetGalleriesNames').subscribe({
      next: (result) => {
        this.galleries.set(result);
      },
      error: (err) => {
        console.error('Error fetching galleries names', err);
      }
    });
  }
}
