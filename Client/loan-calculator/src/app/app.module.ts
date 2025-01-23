import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ClientDropdownComponent } from './components/client-dropdown/client-dropdown.component';
import { LoanFormComponent } from './components/loan-form/loan-form.component';
import { LoanResultComponent } from './components/loan-result/loan-result.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientDropdownComponent,
    LoanFormComponent,
    LoanResultComponent,
  ],
  imports: [BrowserModule, FormsModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
