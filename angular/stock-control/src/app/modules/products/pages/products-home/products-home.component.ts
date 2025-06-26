import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { lastValueFrom, Subject } from 'rxjs';
import { EventAction } from '../../../../models/interfaces/products/event/EventAction';
import { GetAllProductResponse } from '../../../../models/interfaces/products/response/GetAllProductResponse';
import { ProductService } from '../../../../services/product/product.service';
import { ToastService } from '../../../../services/toast/toast.service';
import { ProductDataTranferService } from '../../../../shared/services/productDataTranfer.service';
import { ProductFormComponent } from '../../components/product-form/product-form.component';

@Component({
  selector: 'app-products-home',
  standalone: false,
  templateUrl: './products-home.component.html',
  styleUrls: ['./products-home.component.scss']
})
export class ProductsHomeComponent implements OnInit {

  public readonly destroy$: Subject<void> = new Subject<void>();
  private ref!: DynamicDialogRef;
  public productsList : GetAllProductResponse[] = [];

  constructor(
    private productsService : ProductService,
    private productDtService : ProductDataTranferService,
    private router: Router,
    private toastService: ToastService,
    private dialogService : DialogService
  ) { }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
  ngOnInit() {
    this.getServiceProductsDatas();
  }
  getServiceProductsDatas(){
    const productsLoaded = this.productDtService.getProductsDatas();
    if(productsLoaded.length > 0){
      this.productsList = productsLoaded;
    }else {
      this.getAPIProductsDatas();
    }
  }
  getAPIProductsDatas() {
     lastValueFrom(this.productsService.getAllProducts())
      .then((response: GetAllProductResponse[]) => { 
        this.productsList = response;
        this.productDtService.setProductsDatas(response);
      })
      .catch((error) => {
        console.error('Error fetching products:', error);
        this.toastService.showError('Erro ao buscar produtos.');
        this.router.navigate(['/dashboard']);
      });
  }
  handleProductAction(event : EventAction):void {
    if(event){
      this.ref = this.dialogService.open(ProductFormComponent, {
        header:  event.action,
        width: '70%',
        contentStyle: {
          'overflow': 'auto'
        },
        closable: true,
        modal: true,
        dismissableMask: true,
        baseZIndex: 1000,
        maximizable: false,
        data : {
          event : event,
          productDatas: this.productsList
        }
      });
      this.ref.onClose.subscribe((response) => {
          this.getAPIProductsDatas();
        
      });
    }
  }
  async handleDeleteProductAction(event: { product_id: string, product_name: string }): Promise<void> {
  if (event?.product_id && event?.product_name) {
    try {
      const result = await this.toastService.showConfirmation(
        `Você tem certeza que deseja excluir o produto ${event.product_name}?`,
        'Excluir',
        'Cancelar'
      );

      if (result.isConfirmed) {
        await lastValueFrom(this.productsService.deleteProduct(event.product_id));
        this.toastService.showSuccess(`Produto ${event.product_name} excluído com sucesso!`);
        this.getAPIProductsDatas();
      }
    } catch (error) {
      console.error('Erro ao excluir produto:', error);
      this.toastService.showError(`Erro ao excluir o produto ${event.product_name}.`);
    }
  }
}

}
