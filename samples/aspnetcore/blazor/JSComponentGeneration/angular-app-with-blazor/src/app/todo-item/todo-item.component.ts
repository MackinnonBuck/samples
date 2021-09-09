import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BlazorAdapterComponent } from '../blazor-adapter/blazor-adapter.component';

@Component({
  selector: 'todo-item',
  template: '',
})

export class TodoItemComponent extends BlazorAdapterComponent {
  @Input() index: number | null = null;
  @Output() onRemove: EventEmitter<any> = new EventEmitter();
}
