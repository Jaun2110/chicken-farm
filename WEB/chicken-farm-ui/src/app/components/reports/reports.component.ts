import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardService } from '../../services/dashboard.service';
import { DashboardDto } from '../../models/dashboard.model';

@Component({
  selector: 'app-reports',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './reports.component.html',
  styleUrl: './reports.component.scss'
})
export class ReportsComponent implements OnInit {
  private dashboardService = inject(DashboardService);

  dashboard: DashboardDto | null = null;
  loading = true;

  ngOnInit(): void {
    this.dashboardService.get().subscribe({
      next: (data) => {
        this.dashboard = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Failed to load report', err);
        this.loading = false;
      }
    });
  }

  print(): void {
    window.print();
  }

  exportData(): void {
    if (!this.dashboard) return;
    const data = {
      summary: this.dashboard,
      exportedAt: new Date().toISOString()
    };
    const blob = new Blob([JSON.stringify(data, null, 2)], { type: 'application/json' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = `chicken-farm-backup-${new Date().toISOString().split('T')[0]}.json`;
    a.click();
    URL.revokeObjectURL(url);
  }
}