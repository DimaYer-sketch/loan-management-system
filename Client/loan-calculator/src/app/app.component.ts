import { Component } from '@angular/core';
import { Client } from './models/client';
import { LoanRequest } from './models/loan-request';
import { LoanResponse } from './models/loan-response';
import { LoanService } from './services/loan.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  clients: Client[] = [];
  selectedClientId: number | null = null;
  loanResponse: LoanResponse | null = null;

  constructor(private loanService: LoanService) {}

  ngOnInit(): void {
    this.loanService
      .getClients()
      .subscribe((clients) => (this.clients = clients));
  }

  onClientSelected(clientId: number): void {
    this.selectedClientId = clientId;
  }

  onLoanCalculated(request: LoanRequest): void {
    this.loanService.calculateLoan(request).subscribe((response) => {
      this.loanResponse = response;
    });
  }
}
