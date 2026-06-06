import { HttpClient } from '@angular/common/http';
import { Component, OnInit, signal, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

interface PictureModel {
  id: string;
  urlLocationLowCuality: string;
  urlLocationHighCuality: string;
  title: string;
  description: string;
}

@Component({
  selector: 'app-admin-gallery-detail',
  templateUrl: './admin-gallery-detail.component.html',
  styleUrls: ['./admin-gallery-detail.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule]
})
export class AdminGalleryDetailComponent implements OnInit {
  public pictures = signal<PictureModel[]>([]);
  public galleryId: string = '';

  title: string = '';
  description: string = '';
  base64Picture: string = '';

  constructor(private http: HttpClient, private route: ActivatedRoute, private cdr: ChangeDetectorRef) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.galleryId = id;
        this.getPictures();
      }
    });
  }

  getPictures() {
    if (!this.galleryId) return;
    let endpoint = `/picture/GetGallery?galleryId=${this.galleryId}`;
    this.http.get<PictureModel[]>(endpoint).subscribe({
      next: (result) => {
        this.pictures.set(result);
      },
      error: (error) => {
        console.error('Error fetching gallery pictures', error);
      }
    });
  }

  onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (!input.files || input.files.length === 0) {
      return;
    }
    
    const reader = new FileReader();
    reader.onload = () =>{ 
      this.base64Picture = reader.result as string; 
      this.cdr.detectChanges(); // Obliga a Angular a revisar los cambios
    };
    reader.readAsDataURL(input.files[0]);
  }

  onSubmitPicture() {
    if (!this.galleryId || !this.base64Picture) return;

    this.http.post('/api/admin/AddPicture', {
      idGallery: this.galleryId,
      title: this.title,
      description: this.description,
      base64Picture: this.base64Picture
    }).subscribe({
      next: () => {
        // Limpiar el formulario
        this.title = '';
        this.description = '';
        this.base64Picture = '';
        
        // Recargar las imágenes
        this.getPictures();
      },
      error: (error) => {
        console.error('Error al agregar imagen:', error);
      }
    });   
  }

  deletePicture(id: string) {
    if (confirm('¿Estás seguro de que quieres eliminar esta imagen?')) {
      this.http.delete(`api/admin/DeletePicture/${this.galleryId}/${id}`).subscribe({
        next: () => {
          this.getPictures(); 
        },
        error: (error) => {
          console.error('Error al eliminar imagen:', error);
        }
      });

    }
  }
}
