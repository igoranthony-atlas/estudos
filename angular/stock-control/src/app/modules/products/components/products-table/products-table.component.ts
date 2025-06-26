import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProductEvent } from '../../../../models/enums/products/ProductEvent';
import { DeleteProductAction } from '../../../../models/interfaces/products/event/DeleteProductAction';
import { EventAction } from '../../../../models/interfaces/products/event/EventAction';
import { GetAllProductResponse } from '../../../../models/interfaces/products/response/GetAllProductResponse';

@Component({
  selector: 'app-products-table',
  standalone: false,
  templateUrl: './products-table.component.html',
  styleUrls: ['./products-table.component.scss']
})
export class ProductsTableComponent implements OnInit {
  @Input() products: GetAllProductResponse[] = [];
  @Output() productEvent = new EventEmitter<EventAction>();
  @Output() deleteProductEvent = new EventEmitter<DeleteProductAction>();
  public selectedProducts: GetAllProductResponse | null = null;

  public addProductEvent = ProductEvent.ADD_PRODUCT_EVENT;
  public editProductEvent = ProductEvent.EDIT_PRODUCT_EVENT;

  constructor() { }

  ngOnInit() {
  }

  handleProductEvent(action: string, id?: string): void {
    if (action && action !== '') {
      const productEventData = id && id !== '' ? { action, id } : { action };
      this.productEvent.emit(productEventData);
    }
  }
  handleDeleteProduct(product_id: string, product_name: string): void {
    if (product_id != '' && product_name != '') {
      const deleteProductAction: DeleteProductAction = {
        product_id,
        product_name
      };
      this.deleteProductEvent.emit(deleteProductAction);
    }
  }
}
