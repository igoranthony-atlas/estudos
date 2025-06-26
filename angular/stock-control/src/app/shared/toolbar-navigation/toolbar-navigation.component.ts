import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { ButtonModule } from 'primeng/button';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ToolbarModule } from 'primeng/toolbar';
import { ProductEvent } from '../../models/enums/products/ProductEvent';
import { ProductFormComponent } from '../../modules/products/components/product-form/product-form.component';

@Component({
  selector: 'app-toolbar-navigation',
  imports: [CommonModule,ToolbarModule, ButtonModule, RouterModule],
  standalone: true,
  templateUrl: './toolbar-navigation.component.html',
  styleUrls: ['./toolbar-navigation.component.scss'],
  providers: [CookieService, DialogService]
})
export class ToolbarNavigationComponent {

    private ref!: DynamicDialogRef;
  
  constructor(private router: Router, private cookieService: CookieService, private dialogService: DialogService) {}
  
  handleLogout() {
    this.cookieService.delete('USER_INFO');

    this.router.navigate(['/home'])
  }
  handleSaleProduct(){
    this.ref = this.dialogService.open(ProductFormComponent, {
      header: 'Venda de Produto',
      width: '50%',
      data: {
        event: {
          action: ProductEvent.SALE_PRODUCT_EVENT
        },
        productDatas: []
      }
    });

    this.ref.onClose.subscribe((response) => {
      if (response) {
        console.log('Product sold successfully:', response);
      } else {
        console.log('Product sale cancelled.');
      }
    });
  }
}
