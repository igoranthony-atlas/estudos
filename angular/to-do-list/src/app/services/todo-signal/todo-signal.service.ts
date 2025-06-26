import { Injectable, signal } from '@angular/core';
import { todoKeyLocalStorage } from 'src/app/models/enum/todoKeyLocalStorage';
import { Todo } from 'src/app/models/model/todo.model';

@Injectable({
  providedIn: 'root'
})
export class TodoSignalService {

  public todoStade = signal<Todo[]>([])

  public updateTodos({ id, title, description, done }: Todo): void {
    if ((title && id && description !== null) || undefined) {
      this.todoStade.mutate((todos) => {
        if(todos !== null){
          todos.push(new Todo(id, title, description, done));
        }
      });
    }
  }
  public saveTodosInLocalStorage(): void {
    const todos = JSON.stringify(this.todoStade());
    todos && localStorage.setItem(todoKeyLocalStorage.TODO_LIST, todos);
  }
}
