import { Routes } from '@angular/router';
import { MainLayoutComponent } from './features/main-layout/main-layout.component';

export const routes: Routes = [
    { 
        path: '',
        component: MainLayoutComponent,
        children: [
        { 
            path: 'tasks', 
            loadComponent: () => import('./features/tasks/tasks.component').then(m => m.TasksComponent) 
        },
        { path: '', redirectTo: 'tasks', pathMatch: 'full' }
        ]
    }
];
