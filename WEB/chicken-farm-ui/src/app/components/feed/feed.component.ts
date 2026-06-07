import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FeedService } from '../../services/feed.service';
import { FeedCalculationRequest, FeedCalculationResult } from '../../models/feed.model';

@Component({
  selector: 'app-feed',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './feed.component.html',
  styleUrl: './feed.component.scss'
})
export class FeedComponent {
  private feedService = inject(FeedService);

  feedTypes = ['Starter', 'Grower', 'Layer'];

  request: FeedCalculationRequest = {
    feedType: 'Starter',
    totalKg: 100
  };

  result: FeedCalculationResult | null = null;
  loading = false;

  calculate(): void {
    this.loading = true;
    this.feedService.calculate(this.request).subscribe({
      next: (data) => {
        this.result = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Failed to calculate feed', err);
        this.loading = false;
      }
    });
  }
}