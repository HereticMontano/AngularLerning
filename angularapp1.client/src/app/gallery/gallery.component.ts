import { HttpClient } from '@angular/common/http';
import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

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
  standalone: false
})
export class GalleryComponent implements OnInit {
  public pictures = signal<PictureModel[] | undefined>(undefined);  
  public selectedPicture = signal<PictureModel | null>(null);

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const category = params.get('category');
      if (category) {        
        this.getPictures(category);
      }
    });
  }

  getPictures(category: string) {    
    let endpoint = '/picture/' + category;
      
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
