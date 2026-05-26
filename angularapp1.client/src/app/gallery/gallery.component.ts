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
  public currentCategoria: string = '';

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const categoria = params.get('category');
      if (categoria) {
        this.currentCategoria = categoria;
        this.getPictures(categoria);
      }
    });
  }

  getPictures(categoria: string) {    
    let endpoint = '/picture/' + categoria;
      
    this.http.get<PictureModel[]>(endpoint).subscribe({
      next: (result) => {
        this.pictures.set(result);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}
