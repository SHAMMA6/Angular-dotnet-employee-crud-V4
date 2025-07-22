import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { EmployeeDeleteDialogComponent } from './employee-delete-dialog/employee-delete-dialog.component';

@NgModule({
  declarations: [
    EmployeeListComponent,
    EmployeeFormComponent,
    EmployeeDeleteDialogComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    EmployeeListComponent,
    EmployeeFormComponent,
    EmployeeDeleteDialogComponent
  ]
})
export class EmployeesModule {} 