import { Routes, provideRouter } from '@angular/router';
import { GalleryComponent } from './gallery/gallery.component';
import { AboutMeComponent } from './aboutme/aboutme.component';
import { AdminComponent } from './admin/admin.component';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
  { path: 'gallery/:galleryId', component: GalleryComponent },
  { path: 'aboutme', component: AboutMeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminComponent },
  { path: '', redirectTo: '/gallery/6a1accca753932b2217171d2', pathMatch: 'full' },
  { path: '**', redirectTo: '/gallery/6a1accca753932b2217171d2' } // Ruta por defecto para URLs no encontradas
];
