import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { TodoSignalService } from 'src/app/services/todo-signal/todo-signal.service';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-todo-form',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, MatButtonModule,
    MatCardModule, MatFormFieldModule, MatInputModule, MatDialogModule
  ],
  templateUrl: './todo-form.component.html',
  styleUrls: []
})
export class TodoFormComponent {
  private todosSignalsService = inject(TodoSignalService);
  private dialogRefService = inject(MatDialogRef<HeaderComponent>);

  public allTodos = this.todosSignalsService.todoStade();

  public todosForm = new FormGroup({
    title: new FormControl('', [Validators.required, Validators.minLength(3)]),
    description: new FormControl('', [Validators.required, Validators.minLength(5)])  })

    public handleCreateNewTodo(): void {
      if(this.todosForm.valid) {
        const title = String(this.todosForm.controls['title'].value);
        const description = String(this.todosForm.controls['description'].value);
        const id = this.allTodos.length > 0 ? this.allTodos.length + 1 : 1;
        const done = false;

        this.todosSignalsService.updateTodos({
          id,
          title,
          description,
          done
        })
        this.todosSignalsService.saveTodosInLocalStorage();
        this.handleCloseModal()
      }
    }
    handleCloseModal(): void {
      this.dialogRefService.close();
      this.todosForm.reset();
    }
}
