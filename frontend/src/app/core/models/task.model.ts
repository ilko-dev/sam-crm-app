export enum TaskStatus {
  New = 0,
  InProgress = 1,
  Completed = 2
}

export interface Task {
  id: number;
  title: string;
  description?: string;
  createdAt: string;
  dueDate?: string;
  status: TaskStatus;
  assignedUserId?: number;
  clientId?: number;
  
  assignedUserName?: string;
  clientName?: string;
}