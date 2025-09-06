import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsageResponse } from "../models/UsageResponse";

@Injectable({
  providedIn: 'root'
})
export class UsageService {
  private apiUrl = 'https://localhost:44398/api/UsageSummary';

  constructor(private http: HttpClient) { }

  getUsageSummary(serviceType: string, serviceNumber: string): Observable<UsageResponse> {
    return this.http.get<UsageResponse>(`${this.apiUrl}?serviceType=${serviceType}&serviceNumber=${serviceNumber}`);
  }
}

