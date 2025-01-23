import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientDropdownComponent } from './components/client-dropdown/client-dropdown.component';
import { LoanFormComponent } from './components/loan-form/loan-form.component';

const routes: Routes = [
  { path: '', redirectTo: 'loan-form', pathMatch: 'full' },
  { path: 'loan-form', component: LoanFormComponent },
  { path: 'client-dropdown', component: ClientDropdownComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
