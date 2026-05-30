import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
  standalone: false
})
export class AdminComponent {
  idGallery: string = '';
  title: string = '';
  description: string = '';
  base64Picture: string = '';
  titleGallery: string = '';
  descriptionGallery: string = '';
  constructor(private http: HttpClient) { }

  onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (!input.files || input.files.length === 0) {
      return;
    }
    
    const reader = new FileReader() 
    reader.onload = () => this.base64Picture = reader.result as string;
    reader.readAsDataURL(input.files[0]);
  }

  onSubmitPicture() {

    
    this.http.post('/admin/AddPicture', {
      idGallery: '6a1accca753932b2217171d2', //this.idGallery,
      title: this.title,
      description: this.description,
      base64Picture: this.base64Picture
    }).subscribe({
      next: () => {

        // Limpiar el formulario
        this.idGallery = '';
        this.title = '';
        this.description = '';
        this.base64Picture = '';
      },
      error: (error) => {
        console.error('Error al agregar imagen:', error);
      }
    });   
  }

  onSubmitGalery() {

    const body = {      
      title: this.titleGallery,
      description: this.descriptionGallery,      
    };

    this.http.post('/admin/AddGallery', body).subscribe({
      next: () => {
        this.titleGallery = '';
        this.descriptionGallery = '';      
      },
      error: (error) => {
        console.error('Error al agregar imagen:', error);
      }
    });   
  }
}


