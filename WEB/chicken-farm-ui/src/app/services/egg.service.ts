import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EggRecordDto, CreateEggRecordRequest } from '../models/egg.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EggService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/eggs`;

  getAll(): Observable<EggRecordDto[]> {
    return this.http.get<EggRecordDto[]>(this.apiUrl);
  }

  create(request: CreateEggRecordRequest): Observable<EggRecordDto> {
    return this.http.post<EggRecordDto>(this.apiUrl, request);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
