import { Injectable } from '@angular/core';
import { BehaviorSubject, map, take } from 'rxjs';
import { GetAllProductResponse } from '../../models/interfaces/products/response/GetAllProductResponse';


@Injectable({
  providedIn: 'root'
})
export class ProductDataTranferService {
  public productsDataEmitter$ = new BehaviorSubject<Array<GetAllProductResponse> | null>(null);
  public productsDatas: Array<GetAllProductResponse> = [];

  setProductsDatas(products: Array<GetAllProductResponse>) {
    this.productsDataEmitter$.next(products);
  }

  getProductsDatas(): Array<GetAllProductResponse> {
    this.productsDataEmitter$
    .pipe(
      take(1),
      map((data) => data?.filter((product)=> product.amount > 0))
    )
    .subscribe((data) => {
      if (data) {
        this.productsDatas = data;
      }
    });
    return this.productsDatas;
  }
}
