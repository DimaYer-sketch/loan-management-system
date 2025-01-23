import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LoanRequest } from '../../models/loan-request';

@Component({
  selector: 'app-loan-form',
  templateUrl: './loan-form.component.html',
})
export class LoanFormComponent {
  @Input() clientId: number | null = null;
  @Output() loanCalculated = new EventEmitter<LoanRequest>();

  loanRequest: LoanRequest = { clientId: 0, amount: 0, months: 12 };
  
  onSubmit(): void {
    if (this.clientId !== null) {
      this.loanRequest.clientId = this.clientId;
      this.loanCalculated.emit(this.loanRequest);
    }
  }
}
