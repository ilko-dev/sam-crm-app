import { Component, OnInit } from '@angular/core';
import { CommonModule, CurrencyPipe, DatePipe } from '@angular/common'; // Пайпи для форматування грошей і дат
import { FormsModule } from '@angular/forms';

import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { TagModule } from 'primeng/tag';
import { InputTextModule } from 'primeng/inputtext';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';

export interface Deal {
  id: number;
  title: string;
  clientName: string;
  amount: number;
  stage: 'Lead' | 'Negotiation' | 'Proposal' | 'Won' | 'Lost';
  expectedCloseDate: Date;
}

@Component({
  selector: 'app-deals',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    TableModule,
    ButtonModule,
    TagModule,
    InputTextModule,
    IconFieldModule,
    InputIconModule
  ],
  providers: [CurrencyPipe, DatePipe],
  templateUrl: './deals.component.html'
})
export class DealsComponent implements OnInit {
  deals: Deal[] = [];
  searchQuery: string = '';

  ngOnInit() {
    this.deals = [
      {
        id: 101,
        title: 'Розробка корпоративного сайту',
        clientName: 'ТОВ "Альфа Тех" (Олександр)',
        amount: 4500,
        stage: 'Proposal',
        expectedCloseDate: new Date('2026-04-15')
      },
      {
        id: 102,
        title: 'Поставка 50 ноутбуків',
        clientName: 'Нова Логістика (Марія)',
        amount: 32000,
        stage: 'Negotiation',
        expectedCloseDate: new Date('2026-03-30')
      },
      {
        id: 103,
        title: 'SEO оптимізація (Q2)',
        clientName: 'Індивідуальний підприємець (Іван)',
        amount: 800,
        stage: 'Won',
        expectedCloseDate: new Date('2026-03-20')
      },
      {
        id: 104,
        title: 'Інтеграція 1C',
        clientName: 'ТОВ "МегаБуд"',
        amount: 1200,
        stage: 'Lead',
        expectedCloseDate: new Date('2026-05-01')
      }
    ];
  }

  getStageSeverity(stage: string): "success" | "secondary" | "info" | "warn" | "danger" | "contrast" {
    switch (stage) {
      case 'Won': return 'success';
      case 'Lost': return 'danger';
      case 'Proposal': return 'warn';
      case 'Negotiation': return 'info';
      default: return 'secondary';
    }
  }

  getStageLabel(stage: string): string {
    const labels: Record<string, string> = {
      'Lead': 'Новий лід',
      'Negotiation': 'Перемовини',
      'Proposal': 'КП надіслано',
      'Won': 'Успішно закрито',
      'Lost': 'Відмова'
    };
    return labels[stage] || stage;
  }
  get activePipelineValue(): number {
    return this.deals
      .filter(d => d.stage !== 'Lost' && d.stage !== 'Won')
      .reduce((sum, deal) => sum + deal.amount, 0);
  }

  get wonRevenue(): number {
    return this.deals
      .filter(d => d.stage === 'Won')
      .reduce((sum, deal) => sum + deal.amount, 0);
  }

  get newLeadsCount(): number {
    return this.deals.filter(d => d.stage === 'Lead').length;
  }
}
