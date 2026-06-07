import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EggService } from '../../services/egg.service';
import { EggRecordDto, CreateEggRecordRequest } from '../../models/egg.model';

@Component({
  selector: 'app-eggs',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './eggs.component.html',
  styleUrl: './eggs.component.scss'
})
export class EggsComponent implements OnInit {
  private eggService = inject(EggService);

  eggs: EggRecordDto[] = [];
  loading = true;

  newRecord: CreateEggRecordRequest = {
    date: new Date().toISOString().split('T')[0],
    collected: 0,
    sold: 0,
    pricePerDozen: 45,
    customer: ''
  };

  ngOnInit(): void {
    this.loadEggs();
  }

  loadEggs(): void {
    this.eggService.getAll().subscribe({
      next: (data) => {
        this.eggs = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Failed to load eggs', err);
        this.loading = false;
      }
    });
  }

  addRecord(): void {
    this.eggService.create(this.newRecord).subscribe({
      next: () => {
        this.loadEggs();
        this.resetForm();
      },
      error: (err) => console.error('Failed to add record', err)
    });
  }

  deleteRecord(id: number): void {
    if (!confirm('Delete this record?')) return;
    this.eggService.delete(id).subscribe({
      next: () => this.loadEggs(),
      error: (err) => console.error('Failed to delete record', err)
    });
  }

  private resetForm(): void {
    this.newRecord = {
      date: new Date().toISOString().split('T')[0],
      collected: 0,
      sold: 0,
      pricePerDozen: 45,
      customer: ''
    };
  }
}