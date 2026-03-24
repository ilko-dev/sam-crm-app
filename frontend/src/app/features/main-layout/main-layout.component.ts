import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MenuModule } from 'primeng/menu';
import { MenuItem } from 'primeng/api';
import { PanelMenuModule } from 'primeng/panelmenu';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [CommonModule, RouterModule, MenuModule, PanelMenuModule],
  templateUrl: './main-layout.component.html'
})
export class MainLayoutComponent implements OnInit {
  items: MenuItem[] | undefined;

  ngOnInit() {
    this.items = [
      {
        label: 'ОСНОВНЕ',
        items: [
          { label: 'Головна сторінка', icon: 'pi pi-home', routerLink: '/dashboard' },
          { label: 'Профіль', icon: 'pi pi-user', routerLink: '/profile' }
        ]
      },
      {
        label: 'БІЗНЕС-ПРОЦЕСИ',
        items: [
          { label: 'Клієнти', icon: 'pi pi-users', routerLink: '/clients' },
          { label: 'Угоди', icon: 'pi pi-briefcase', routerLink: '/deals', routerLinkActiveOptions: { exact: true } },
          { label: 'Задачі', icon: 'pi pi-check-square', routerLink: '/tasks', routerLinkActiveOptions: { exact: true } }
        ]
      },
      {
        label: 'СИСТЕМА',
        items: [
          { label: 'Налаштування', icon: 'pi pi-cog', routerLink: '/settings' },
          { label: 'SAM', icon: 'pi pi-sparkles', routerLink: '/sam', styleClass: 'text-purple-600 font-bold' } 
        ]
      }
    ];
  }
}
