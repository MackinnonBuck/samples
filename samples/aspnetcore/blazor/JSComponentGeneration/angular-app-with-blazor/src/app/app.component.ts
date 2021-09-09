import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <div class="content">
      <h1>Welcome to {{title}}!</h1>
      <p>This is an Angular application that can also host Blazor components.</p>
      <p>
        <button (click)="addTodoItem()">Add TODO item</button>
      </p>

      <div *ngFor="let todoItem of todoItems">
        <!-- TODO: Render the TODO items list? -->
        <todo-item
          [index]="todoItem.index"
          (onRemove)="removeTodoItem(todoItem.index)">
        </todo-item>
      </div>
    </div>
  `,
  styles: []
})
export class AppComponent {
  title = 'angular-app-with-blazor';

  todoItems: any[] = [];

  addTodoItem() {
    this.todoItems.push({
      index: this.todoItems.length,
    });
  }

  removeTodoItem(index: number) {
    this.todoItems.splice(index, 1);

    for (let i = index; i < this.todoItems.length; i++) {
      this.todoItems[i].index = i;
    }
  }
}
