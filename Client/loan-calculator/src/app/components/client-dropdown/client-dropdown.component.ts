import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LoanService } from '../../services/loan.service';
import { Client } from '../../models/client';

@Component({
  selector: 'app-client-dropdown',
  templateUrl: './client-dropdown.component.html',
  styleUrls: ['./client-dropdown.component.scss'],
})
export class ClientDropdownComponent implements OnInit {
  clients: Client[] = [];
  selectedClientId: number | null = null;

  @Output() clientSelected = new EventEmitter<number>();

  constructor(private loanService: LoanService) {}

  ngOnInit(): void {
    this.loanService.getClients().subscribe({
      next: (data) => {
        this.clients = data;
        console.log('test clients = ', this.clients);
      },
      error: (err) => {
        console.error('Error fetching clients:', err);
      },
    });
  }

  onClientChange(): void {
    if (this.selectedClientId !== null) {
      this.clientSelected.emit(this.selectedClientId);
    }
  }
}
