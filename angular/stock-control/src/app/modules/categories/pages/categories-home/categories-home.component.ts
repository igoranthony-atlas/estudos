import { Component, OnInit } from '@angular/core';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { lastValueFrom } from 'rxjs';
import { GetCategoriesResponse } from '../../../../models/interfaces/categories/response/GetCategoriesResponse';
import { EventAction } from '../../../../models/interfaces/products/event/EventAction';
import { CategoriesService } from '../../../../services/categories/categories.service';
import { ToastService } from '../../../../services/toast/toast.service';
import { CategoryFormComponent } from '../../components/category-form/category-form.component';

@Component({
  selector: 'app-categories-home',
  templateUrl: './categories-home.component.html',
  styleUrls: [],
  standalone: false
})
export class CategoriesHomeComponent implements OnInit {
  public categoriesDatas: GetCategoriesResponse[] = [];
  private ref!: DynamicDialogRef;
  constructor(
    private categoriesService: CategoriesService,
    private dialogService: DialogService,
    private toastService: ToastService
  ) { }

  ngOnInit() {
    this.getAllCategories();
  }
  async getAllCategories() {
    await lastValueFrom(this.categoriesService.getAllCategories())
      .then((response) => {
        if (response) {
          this.categoriesDatas = response;
        } else {
          this.toastService.showError('Erro ao buscar categorias');
        }
      })
      .catch((error) => {
        console.error('Error fetching categories:', error);
      }
    );
  }
  async handleDeleteCategoryAction(event: { category_id: string; categoryName: string }) {
    if(event ){
      try {
        const result = await this.toastService.showConfirmation(
        `Você tem certeza que deseja excluir a categoria ${event.categoryName}?`,
        'Excluir',
        'Cancelar'
      );
      if (result.isConfirmed) {
         await this.deleteCategory(event.category_id);
      }
      }catch (error) {
        console.error('Error showing confirmation:', error);
        this.toastService.showError('Erro ao excluir uma categoria.');
      }
    }
  }
  async deleteCategory(category_id: string) {
    if (category_id) {
      await lastValueFrom(this.categoriesService.deleteCategory(category_id))
        .then(() => {
          
            this.toastService.showSuccess('Categoria excluída com sucesso!');
            this.getAllCategories();
          
        })
        .catch((error) => {
          console.error('Error deleting category:', error);
          this.toastService.showError('Erro ao excluir a categoria');
        }
      );
    } 
  }
  handleCategoryAction(event: EventAction) {
    if(event){
      this.ref = this.dialogService.open(CategoryFormComponent, {
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
          event: event
        }
      })
      this.ref.onClose.subscribe(()=> {
        this.getAllCategories();
      })
    }
  }
}
