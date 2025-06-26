import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CategoryEvent } from '../../../../models/enums/categories/CategoryEvent';
import { EditCategoryAction } from '../../../../models/interfaces/categories/event/EditCategoryAction';
import { GetCategoriesResponse } from '../../../../models/interfaces/categories/response/GetCategoriesResponse';

@Component({
  selector: 'app-categories-table',
  standalone: false,
  templateUrl: './categories-table.component.html'
})
export class CategoriesTableComponent {
  @Input() categories: GetCategoriesResponse[] = [];
  @Output() public categoryEvent = new EventEmitter<EditCategoryAction>();
  @Output() public deleteCategoryEvent = new EventEmitter<{ category_id: string; categoryName: string }>();
  public categorySelected!: GetCategoriesResponse;
  public addCategoryAction = CategoryEvent.ADD_CATEGORY_ACTION;
  public editCategoryAction = CategoryEvent.EDIT_CATEGORY_ACTION;

  constructor() { }

  handleDeleteCategoryEvent(category_id: string, categoryName: string) {
    if (category_id && categoryName) {
      this.deleteCategoryEvent.emit({ category_id, categoryName });
    }
  }
  handleCategoryEvent(action: string, id?: string, categoryName?: string): void {
    if(action && action !== ''){
      this.categoryEvent.emit({
        action: action,
        id: id,
        categoryName: categoryName
      });
    }
  }
}
