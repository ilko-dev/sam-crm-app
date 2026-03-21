import { Component } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';

@Component({
  selector: 'app-task-list',
  imports: [SharedModule],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.scss',
})
export class TaskListComponent {
  tasks = [
      { id: 1, title: 'Business Plan', description: '...', status: 'New', priority: 'High', dueDate: '2025-11-20' },
      { id: 2, title: 'Setup Angular', description: '...', status: 'In Progress', priority: 'Medium', dueDate: '2025-11-21' }
  ];
}
