import { Routes } from '@angular/router';
import { GalleryComponent } from './gallery/gallery.component';
import { AboutMeComponent } from './aboutme/aboutme.component';
import { AdminComponent } from './admin/admin.component';
import { LoginComponent } from './login/login.component';
import { AdminGalleryDetailComponent } from './admin-gallery-detail/admin-gallery-detail.component';

export const routes: Routes = [
  { path: 'gallery/:galleryId', component: GalleryComponent },
  { path: 'aboutme', component: AboutMeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'admin/gallery/:id', component: AdminGalleryDetailComponent },  
  { path: '**', redirectTo: 'aboutme' } // Ruta por defecto para URLs no encontradas
];
