import { HttpClient } from '@angular/common/http';
import { Component, OnInit, signal } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-mural',
  templateUrl: './mural.component.html',
  standalone: false
})
export class MuralComponent implements OnInit {
  public forecasts = signal<WeatherForecast[] | undefined>(undefined);

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe({
      next: (result) => {
        this.forecasts.set(result);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}
