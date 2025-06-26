import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WeatherDatas } from '../../../models/interfaces/WeatherDatas';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  private apiKey = 'e6cfe89df815a11fc55451809da9ca39';

  constructor(private http: HttpClient) {}

  getWeatherDatas(city: string): Observable<WeatherDatas> {
    const url = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${this.apiKey}&units=metric`;
    return this.http.get<WeatherDatas>(url);
  }
}
