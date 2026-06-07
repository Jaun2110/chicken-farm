import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PaddockService } from '../../services/paddock.service';
import { PaddockDto, CreatePaddockRequest } from '../../models/paddock.model';

@Component({
  selector: 'app-paddocks',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './paddocks.component.html',
  styleUrl: './paddocks.component.scss'
})
export class PaddocksComponent implements OnInit {
  private paddockService = inject(PaddockService);

  paddocks: PaddockDto[] = [];
  loading = true;

  newPaddock: CreatePaddockRequest = {
    name: '',
    dateIn: new Date().toISOString().split('T')[0],
    dateOut: null,
    notes: ''
  };

  ngOnInit(): void {
    this.loadPaddocks();
  }

  loadPaddocks(): void {
    this.paddockService.getAll().subscribe({
      next: (data) => {
        this.paddocks = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Failed to load paddocks', err);
        this.loading = false;
      }
    });
  }

  addPaddock(): void {
    this.paddockService.create(this.newPaddock).subscribe({
      next: () => {
        this.loadPaddocks();
        this.resetForm();
      },
      error: (err) => console.error('Failed to add paddock', err)
    });
  }

  deletePaddock(id: number): void {
    if (!confirm('Delete this paddock record?')) return;
    this.paddockService.delete(id).subscribe({
      next: () => this.loadPaddocks(),
      error: (err) => console.error('Failed to delete paddock', err)
    });
  }

  private resetForm(): void {
    this.newPaddock = {
      name: '',
      dateIn: new Date().toISOString().split('T')[0],
      dateOut: null,
      notes: ''
    };
  }
}