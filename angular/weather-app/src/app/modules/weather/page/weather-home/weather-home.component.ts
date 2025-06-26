import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';
import { lastValueFrom } from 'rxjs';
import { WeatherDatas } from '../../../../models/interfaces/WeatherDatas';
import { WeatherCardComponent } from "../../components/weather-card/weather-card.component";
import { WeatherService } from '../../services/weather.service';
@Component({
  selector: 'app-weather-home',
  imports: [CommonModule, FormsModule, FontAwesomeModule, WeatherCardComponent],
  templateUrl: './weather-home.component.html'
})
export class WeatherHomeComponent {
  city: string = 'São Paulo';
  weatherDatas!: WeatherDatas;
  searchIcon = faMagnifyingGlass;
  constructor(
    private weatherService: WeatherService
  ){}

  ngOnInit(): void {
    this.getWeatherData(this.city);
  }
  
  getWeatherData(cityName: string) {
    lastValueFrom(this.weatherService.getWeatherDatas(cityName))
    .then(data => {
      this.weatherDatas = data;
      console.log('Weather data fetched successfully:', this.weatherDatas);
    }).catch(error => { 
      console.error('Error fetching weather data:', error);
    });
  }
  onSubmit() {
    this.getWeatherData(this.city);
    this.city = '';
  }
}
