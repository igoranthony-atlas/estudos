import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { map, Observable } from 'rxjs';
import { environment } from '../../../environments/environments';
import { CreateProductRequest } from '../../models/interfaces/products/request/CreateProductRequest';
import { EditProductRequest } from '../../models/interfaces/products/request/EditProductRequest';
import { SaleProductRequest } from '../../models/interfaces/products/request/SaleProductRequest';
import { CreateProductResponse } from '../../models/interfaces/products/response/CreateProductResponse';
import { DeleteProductReponse } from '../../models/interfaces/products/response/DeleteProductResponse';
import { GetAllProductResponse } from '../../models/interfaces/products/response/GetAllProductResponse';
import { SaleProductResponse } from '../../models/interfaces/products/response/SaleProductResponse';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = environment.API_URL
  
  constructor(private http: HttpClient, private cookieService: CookieService) {
    
  }
  getHeaders(){
    const token = this.cookieService.get('USER_INFO');
    return {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    };
  }
  getAllProducts(): Observable<Array<GetAllProductResponse>>{
    return this.http.get<Array<GetAllProductResponse>>(`${this.apiUrl}/products`, {
      headers: this.getHeaders()
    }).pipe(
      map((product) => product.filter((data) => data?.amount > 0))
    );
  }
  deleteProduct(product_id: string): Observable<DeleteProductReponse> {
    return this.http.delete<DeleteProductReponse>(`${this.apiUrl}/product/delete`, {
      headers: this.getHeaders(),
      params: { product_id }
    });
  }
  createProduct(requestData : CreateProductRequest) : Observable<CreateProductResponse> {
    return this.http.post<CreateProductResponse>(`${this.apiUrl}/product`, requestData, {
      headers: this.getHeaders()
    });
  }
  editProduct(requestData: EditProductRequest): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/product/edit`, requestData, {
      headers: this.getHeaders()
    });
  }
  saleProduct(requestData: SaleProductRequest): Observable<SaleProductResponse>{
    return this.http.post<SaleProductResponse>(`${this.apiUrl}/product/sale`, {
      amount: requestData.amount,
    }
    , {
      headers: this.getHeaders(),
      params: { product_id: requestData.product_id }
    })
  }
}
