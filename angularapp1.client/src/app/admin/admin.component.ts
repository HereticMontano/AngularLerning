import { HttpClient } from '@angular/common/http';
import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

interface GalleryNameModel {
  id: string;
  title: string;
}

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule]
})
export class AdminComponent implements OnInit {
  titleGallery: string = '';  
  public galleries = signal<GalleryNameModel[]>([]);

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getGalleries();
  }

  getGalleries() {
    this.http.get<GalleryNameModel[]>('/picture/GetGalleriesNames').subscribe({
      next: (result) => {
        this.galleries.set(result);
      },
      error: (error) => {
        console.error('Error fetching galleries', error);
      }
    });
  }

  onSubmitGalery() {
    const body = {      
      title: this.titleGallery,         
    };

    this.http.post('/api/admin/AddGallery', body).subscribe({
      next: () => {
        this.titleGallery = '';        
        this.getGalleries(); // Refrescar la lista de galerías
      },
      error: (err) => {
        alert(err.error);
      }
    });   
  }

  deleteGallery(id: string) {
    if (confirm('¿Estás seguro de que quieres eliminar esta galería y todas sus imágenes?')) {
      this.http.delete(`/api/admin/DeleteGallery/${id}`).subscribe({
        next: () => {
          this.getGalleries(); // Refresh after deletion
        },
        error: (err) => {
          alert(err.error);
        }
      });
    }
  }
}
