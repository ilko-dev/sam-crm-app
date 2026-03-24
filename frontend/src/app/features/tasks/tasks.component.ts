import { Component, inject, signal, computed, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { TagModule } from 'primeng/tag';
import { TableModule } from 'primeng/table';
import { ProgressSpinnerModule } from 'primeng/progressspinner';

import { Task, TaskStatus } from '../../core/models/task.model';
import { TaskService } from '../../core/services/task.service';

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
    TableModule,
    ProgressSpinnerModule
  ],
  templateUrl: './tasks.component.html'
})
export class TasksComponent implements OnInit {
  private taskService = inject(TaskService);
  
  TaskStatus = TaskStatus; // Expose to template
  
  tasks = signal<Task[]>([]);
  viewMode = signal<'list' | 'table' | 'kanban'>('list');
  newTaskTitle = signal('');
  isLoading = signal(true);

  filteredTasks = computed(() => this.tasks());

  constructor() {}

  ngOnInit() {
    this.loadTasks();
  }

  loadTasks() {
    this.isLoading.set(true);
    this.taskService.getTasks().subscribe({
      next: (data) => {
        this.tasks.set(data);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Помилка завантаження задач:', err);
        this.isLoading.set(false);
      }
    });
  }

  getStatusLabel(status: TaskStatus): string {
    switch(status) {
      case TaskStatus.New: return 'Нова';
      case TaskStatus.InProgress: return 'В роботі';
      case TaskStatus.Completed: return 'Виконана';
      default: return 'Невідомо';
    }
  }

  getStatusSeverity(status: TaskStatus): "success" | "secondary" | "info" | "warn" | "danger" | "contrast" {
    switch(status) {
      case TaskStatus.Completed: return 'success';
      case TaskStatus.InProgress: return 'info';
      default: return 'secondary';
    }
  }

  addTask() {
    const title = this.newTaskTitle().trim();
    if (title) {
      this.taskService.createTask({ title, status: TaskStatus.New }).subscribe({
        next: (newTask) => {
          this.tasks.update(tasks => [newTask, ...tasks]);
          this.newTaskTitle.set('');
        },
        error: (err) => {
          console.error('Помилка створення задачі:', err);
        }
      });
    }
  }

  deleteTask(id: number) {
    this.taskService.deleteTask(id).subscribe({
      next: () => {
        this.tasks.update(tasks => tasks.filter(t => t.id !== id));
      },
      error: (err) => {
        console.error('Помилка видалення задачі:', err);
      }
    });
  }

  onTaskStatusChange(task: Task, completed: boolean) {
    const newStatus = completed ? TaskStatus.Completed : TaskStatus.New;
    this.taskService.updateTaskStatus(task.id, newStatus).subscribe({
      next: () => {
        this.tasks.update(tasks => 
          tasks.map(t => t.id === task.id ? { ...t, status: newStatus } : t)
        );
      },
      error: (err) => {
        console.error('Помилка оновлення статусу:', err);
      }
    });
  }
}