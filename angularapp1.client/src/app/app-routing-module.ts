import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GalleryComponent } from './gallery/gallery.component';
import { AboutMeComponent } from './aboutme/aboutme.component';

const routes: Routes = [
  { path: 'gallery/:category', component: GalleryComponent },
  { path: 'aboutme', component: AboutMeComponent },
  { path: '', redirectTo: '/gallery/mural', pathMatch: 'full' },
  { path: '**', redirectTo: '/gallery/mural' } // Ruta por defecto para URLs no encontradas
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
