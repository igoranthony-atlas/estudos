import { CommonModule } from '@angular/common';
import { Component, computed, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTabsModule } from '@angular/material/tabs';
import { todoKeyLocalStorage } from 'src/app/models/enum/todoKeyLocalStorage';
import { Todo } from 'src/app/models/model/todo.model';
import { TodoSignalService } from 'src/app/services/todo-signal/todo-signal.service';

@Component({
  selector: 'app-tod-card',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatButtonModule, MatIconModule,
     MatTabsModule],
  templateUrl: './tod-card.component.html',
  styleUrls: ['./tod-card.component.scss']
})
export class TodCardComponent {
  private todosSignalService = inject(TodoSignalService);
  private todoSignal = this.todosSignalService.todoStade;
  public todosList = computed(() => this.todoSignal());

  ngOnInit() {
    this.getTodoInLocalStorage()
  }

  public getTodoInLocalStorage() {
    const todos = localStorage.getItem(todoKeyLocalStorage.TODO_LIST) as string;
    todos && this.todoSignal.set(JSON.parse(todos));
  }
  private saveTodoInLocalStorage() {
    this.todosSignalService.saveTodosInLocalStorage();
  }
  public handleDoneTodo(id: number): void {
    if (id) {
      this.todoSignal.mutate((todos) => {
        const todoSelected = todos.find(todo => todo.id === id);
        if (todoSelected) {
          todoSelected.done = true;
          this.saveTodoInLocalStorage();
        }
      })
    }
  }
  public handleDeleteTodo(todo: Todo): void {
    if (todo) {
      const index = this.todosList().indexOf(todo);
      if (index !== -1) {
        this.todoSignal.mutate((todos) => {
          todos.splice(index, 1);
          this.saveTodoInLocalStorage();
        })
      }

    }
  }
}
