import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { TagModule } from 'primeng/tag';
import { TableModule } from 'primeng/table';

interface Task {
  id: number;
  title: string;
  completed: boolean;
  priority: 'High' | 'Medium' | 'Low';
}

@Component({
  selector: 'app-tasks',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    InputTextModule, 
    ButtonModule, 
    CheckboxModule, 
    TagModule,
    TableModule
  ],
  templateUrl: './tasks.component.html'
})
export class TasksComponent {
  viewMode: 'list' | 'table' | 'kanban' = 'list';

  tasks: Task[] = [
    { id: 1, title: 'Зателефонувати клієнту ТОВ "Альфа"', completed: false, priority: 'High' },
    { id: 2, title: 'Підготувати звіт за березень', completed: true, priority: 'Medium' },
    { id: 3, title: 'Оновити статуси угод в SAM CRM', completed: false, priority: 'Low' }
  ];

  newTaskTitle: string = '';

  addTask() {
    if (this.newTaskTitle.trim()) {
      this.tasks.unshift({
        id: Date.now(),
        title: this.newTaskTitle,
        completed: false,
        priority: 'Medium'
      });
      this.newTaskTitle = '';
    }
  }

  deleteTask(id: number) {
    this.tasks = this.tasks.filter(t => t.id !== id);
  }
}