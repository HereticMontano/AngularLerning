import { HttpClient } from '@angular/common/http';
import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

interface PictureModel {
  urlLocationLowCuality: string;
  urlLocationHighCuality: string;
  title: string;
  description: string;
}

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class GalleryComponent implements OnInit {
  public pictures = signal<PictureModel[] | undefined>(undefined);  
  public selectedPicture = signal<PictureModel | null>(null);

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const galleryId = params.get('galleryId');
      if (galleryId) {        
        this.getPictures(galleryId);
      }
    });
  }

  getPictures(galleryId: string) {    
    let endpoint = `/picture/GetGallery?galleryId=${galleryId}`;
      
    this.http.get<PictureModel[]>(endpoint).subscribe({
      next: (result) => {
        this.pictures.set(result);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  openModal(picture: PictureModel) {
    this.selectedPicture.set(picture);
  }

  closeModal() {
    this.selectedPicture.set(null);
  }
}
