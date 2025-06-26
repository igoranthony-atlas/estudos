import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { lastValueFrom } from 'rxjs';
import { CategoryEvent } from '../../../../models/enums/categories/CategoryEvent';
import { EditCategoryAction } from '../../../../models/interfaces/categories/event/EditCategoryAction';
import { CategoriesService } from '../../../../services/categories/categories.service';
import { ToastService } from '../../../../services/toast/toast.service';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  standalone: false,
  styleUrls: []
})
export class CategoryFormComponent implements OnInit {

  private addCategoryAction = CategoryEvent.ADD_CATEGORY_ACTION;
  private editCategoryAction = CategoryEvent.EDIT_CATEGORY_ACTION;

  public categoryAction!: { event: EditCategoryAction };
  public categoryForm!: FormGroup;

  constructor(
    public ref: DynamicDialogConfig,
    public formBuilder: FormBuilder,
    private toastService: ToastService,
    private categoriesService: CategoriesService,
    public refDialog: DynamicDialogRef,

  ) { }

  ngOnInit() {
    this.startForms();
    this.categoryAction = this.ref.data;
    if(this.categoryAction?.event.action === this.editCategoryAction) {
      this.setCategoryName(this.categoryAction.event.categoryName as string);
    }
  }

  startForms() {
    this.categoryForm = this.formBuilder.group({
      name: ['', Validators.required]
    });
  }
  handleSubmitCategoryAction(){
    if(this.categoryAction.event.action === this.addCategoryAction) {
      this.handleSubmitAddCategory();
    }
    if(this.categoryAction.event.action === this.editCategoryAction) {
      this.handleSubmitEditCategory();
    }
  }
  async handleSubmitEditCategory() {
    if (this.categoryForm.valid) {
      const requestEditCategory : { category_id: string, name: string } = {
        category_id: this.categoryAction.event.id as string,
        name: this.categoryForm.value.name
      }
      await lastValueFrom(this.categoriesService.editCategory(requestEditCategory))
        .then(() => {
          this.categoryForm.reset();
          this.toastService.showSuccess('Categoria editada com sucesso!');
          this.refDialog.close(true);
        })
        .catch((error) => {
          console.error('Error editing category:', error);
          this.toastService.showError('Erro ao editar categoria.');
        });
    }
  }
  setCategoryName(categoryName: string) {
    if(categoryName){
      this.categoryForm.setValue({ name: categoryName });
    }
  }
  async handleSubmitAddCategory() {
    if (this.categoryForm.valid) {
      await lastValueFrom(this.categoriesService.createNewCategory(this.categoryForm.value))
        .then(() => {
          this.categoryForm.reset();
          this.toastService.showSuccess('Categoria criada com sucesso!');
          this.refDialog.close(true);
        })
        .catch((error) => {
          console.error('Error creating category:', error);
          this.toastService.showError('Erro ao criar categoria.');
        });
    }
  }
}
