import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FlockDto, CreateFlockRequest } from '../models/flock.model';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class FlockService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/flocks`;

  getAll(): Observable<FlockDto[]> {
    return this.http.get<FlockDto[]>(this.apiUrl);
  }

  create(request: CreateFlockRequest): Observable<FlockDto> {
    return this.http.post<FlockDto>(this.apiUrl, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
