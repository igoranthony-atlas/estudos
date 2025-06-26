import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environments';
import { GetCategoriesResponse } from '../../models/interfaces/categories/response/GetCategoriesResponse';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  private API_URL = environment.API_URL;

  getHeaders(){
    const token = this.cookieService.get('USER_INFO');
    return {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    };
  }

  constructor(
    private http: HttpClient,
    private cookieService: CookieService
  ) { }

  getAllCategories() : Observable<GetCategoriesResponse[]>{
    return this.http.get<GetCategoriesResponse[]>(`${this.API_URL}/categories`, {
      headers: this.getHeaders()
    });
  }
  deleteCategory(category_id: string): Observable<void> {
    return this.http.delete<void>(`${this.API_URL}/category/delete`, {
      headers: this.getHeaders(),
      params: { category_id }
    });
  }
  createNewCategory(categoryData: { name: string }): Observable<GetCategoriesResponse[]> {
    return this.http.post<GetCategoriesResponse[]>(`${this.API_URL}/category`, categoryData, {
      headers: this.getHeaders()
    });
  }
  editCategory(categoryData: { category_id: string, name: string }): Observable<void> {
    return this.http.put<void>(`${this.API_URL}/category/edit`, 
      { name: categoryData.name},
      {
      headers: this.getHeaders(),
      params: { category_id: categoryData.category_id }
    });
  }
}
