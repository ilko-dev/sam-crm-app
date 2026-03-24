import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { TagModule } from 'primeng/tag';
import { AvatarModule } from 'primeng/avatar';
import { InputTextModule } from 'primeng/inputtext';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';

export interface Client {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phone?: string;
  companyName?: string;
  createdAt: Date;
  status: 'New' | 'Active' | 'VIP';
}

@Component({
  selector: 'app-clients',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    TableModule,
    ButtonModule,
    TagModule,
    AvatarModule,
    InputTextModule,
    IconFieldModule,
    InputIconModule
  ],
  templateUrl: './clients.component.html'
})
export class ClientsComponent implements OnInit {
  clients: Client[] = [];
  searchQuery: string = '';

  ngOnInit() {
    this.clients = [
      {
        id: 1,
        firstName: 'Олександр',
        lastName: 'Шевченко',
        email: 'a.shevchenko@gmail.com',
        phone: '+380 50 123 45 67',
        companyName: 'ТОВ "Альфа Тех"',
        createdAt: new Date('2026-03-10'),
        status: 'VIP'
      },
      {
        id: 2,
        firstName: 'Марія',
        lastName: 'Коваленко',
        email: 'm.kovalenko@nova-poshta.ua',
        phone: '+380 67 987 65 43',
        companyName: 'Нова Логістика',
        createdAt: new Date('2026-03-20'),
        status: 'Active'
      },
      {
        id: 3,
        firstName: 'Іван',
        lastName: 'Петренко',
        email: 'ivan.p@startup.co',
        companyName: 'Індивідуальний підприємець',
        createdAt: new Date('2026-03-22'),
        status: 'New'
      }
    ];
  }

  getInitials(firstName: string, lastName: string): string {
    return `${firstName.charAt(0)}${lastName.charAt(0)}`.toUpperCase();
  }
}