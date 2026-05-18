import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClimaComponent } from './clima/clima.component';
import { AboutMeComponent } from './aboutme/aboutme.component';

const routes: Routes = [
  { path: 'clima', component: ClimaComponent },
  { path: 'aboutme', component: AboutMeComponent },
  { path: '', redirectTo: '/clima', pathMatch: 'full' },
  { path: '**', redirectTo: '/clima' } // Ruta por defecto para URLs no encontradas
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
