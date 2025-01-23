import { Component, Input } from '@angular/core';
import { LoanResponse } from '../../models/loan-response';

@Component({
  selector: 'app-loan-result',
  templateUrl: './loan-result.component.html',
})
export class LoanResultComponent {
  @Input() loanResponse: LoanResponse | null = null;
}
