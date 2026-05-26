import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MuralComponent } from './mural/mural.component';
import { AboutMeComponent } from './aboutme/aboutme.component';

const routes: Routes = [
  { path: 'mural', component: MuralComponent },
  { path: 'aboutme', component: AboutMeComponent },
  { path: '', redirectTo: '/mural', pathMatch: 'full' },
  { path: '**', redirectTo: '/mural' } // Ruta por defecto para URLs no encontradas
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
