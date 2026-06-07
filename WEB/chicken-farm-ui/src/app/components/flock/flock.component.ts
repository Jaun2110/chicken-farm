import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FlockService } from '../../services/flock.service';
import { FlockDto, CreateFlockRequest } from '../../models/flock.model';

@Component({
  selector: 'app-flock',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './flock.component.html',
  styleUrl: './flock.component.scss'
})
export class FlockComponent implements OnInit {
  private flockService = inject(FlockService);

  flocks: FlockDto[] = [];
  loading = true;

  newFlock: CreateFlockRequest = {
    name: '',
    arrivalDate: new Date().toISOString().split('T')[0],
    startBirds: 100,
    currentBirds: 100,
    breed: '',
    notes: ''
  };

  ngOnInit(): void {
    this.loadFlocks();
  }

  loadFlocks(): void {
    this.flockService.getAll().subscribe({
      next: (data) => {
        this.flocks = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Failed to load flocks', err);
        this.loading = false;
      }
    });
  }

  addFlock(): void {
    this.flockService.create(this.newFlock).subscribe({
      next: () => {
        this.loadFlocks();
        this.resetForm();
      },
      error: (err) => console.error('Failed to add flock', err)
    });
  }

  deleteFlock(id: number): void {
    if (!confirm('Delete this flock?')) return;
    this.flockService.delete(id).subscribe({
      next: () => this.loadFlocks(),
      error: (err) => console.error('Failed to delete flock', err)
    });
  }

  private resetForm(): void {
    this.newFlock = {
      name: '',
      arrivalDate: new Date().toISOString().split('T')[0],
      startBirds: 100,
      currentBirds: 100,
      breed: '',
      notes: ''
    };
  }
}