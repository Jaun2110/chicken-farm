import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaddockDto, CreatePaddockRequest } from '../models/paddock.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PaddockService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/paddocks`;

  getAll(): Observable<PaddockDto[]> {
    return this.http.get<PaddockDto[]>(this.apiUrl);
  }

  create(request: CreatePaddockRequest): Observable<PaddockDto> {
    return this.http.post<PaddockDto>(this.apiUrl, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
