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
            { 
                path: 'clients', 
                loadComponent: () => import('./features/clients/clients.component').then(m => m.ClientsComponent) 
            },
            { 
                path: 'deals', 
                loadComponent: () => import('./features/deals/deals.component').then(m => m.DealsComponent) 
            },
            { path: '', redirectTo: 'tasks', pathMatch: 'full' }
        ]
    }
];