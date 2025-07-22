import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-employee-delete-dialog',
  templateUrl: './employee-delete-dialog.component.html',
  styleUrls: ['./employee-delete-dialog.component.scss']
})
export class EmployeeDeleteDialogComponent {
  @Input() employeeName: string = '';
  @Output() confirm = new EventEmitter<void>();
  @Output() cancel = new EventEmitter<void>();
} 