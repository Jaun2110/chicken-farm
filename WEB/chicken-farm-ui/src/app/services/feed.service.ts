import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {
  FeedCalculationRequest,
  FeedCalculationResult,
} from '../models/feed.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class FeedService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/feed/calculate`;

  calculate(
    request: FeedCalculationRequest,
  ): Observable<FeedCalculationResult> {
    return this.http.post<FeedCalculationResult>(this.apiUrl, request);
  }
}
