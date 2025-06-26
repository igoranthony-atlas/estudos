import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faDroplet, faTemperatureHigh, faTemperatureLow, faWind } from '@fortawesome/free-solid-svg-icons';
import { WeatherDatas } from '../../../../models/interfaces/WeatherDatas';

@Component({
  selector: 'app-weather-card',
  imports: [CommonModule, FontAwesomeModule],
  templateUrl: './weather-card.component.html'
})
export class WeatherCardComponent {
  @Input() weatherData!: WeatherDatas;
  
  minTemperatureIcon = faTemperatureLow;
  maxTemperatureIcon = faTemperatureHigh;
  humidityIcon = faDroplet;
  windIcon = faWind;
}
