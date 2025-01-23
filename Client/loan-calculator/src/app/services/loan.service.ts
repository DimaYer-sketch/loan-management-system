import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from '../models/client';
import { LoanRequest } from '../models/loan-request';
import { LoanResponse } from '../models/loan-response';
import { environment } from '../environment';

@Injectable({
  providedIn: 'root',
})
export class LoanService {
  private apiUrl = `${environment.apiUrl}/Loan`;

  constructor(private http: HttpClient) {}

  getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(`${this.apiUrl}/clients`);
  }

  calculateLoan(request: LoanRequest): Observable<LoanResponse> {
    return this.http.post<LoanResponse>(`${this.apiUrl}/calculate`, request);
  }
}
