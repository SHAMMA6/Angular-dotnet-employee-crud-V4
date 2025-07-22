import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../../../core/models/employee.model';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.scss']
})
export class EmployeeFormComponent implements OnInit {
  @Input() employee: Employee | null = null;
  @Output() save = new EventEmitter<Employee>();
  form!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.form = this.fb.group({
      firstName: [this.employee?.firstName || '', Validators.required],
      lastName: [this.employee?.lastName || '', Validators.required],
      email: [this.employee?.email || '', [Validators.required, Validators.email]],
      position: [this.employee?.position || '', Validators.required]
    });
  }

  onSubmit() {
    if (this.form.valid) {
      const value = { ...this.employee, ...this.form.value };
      this.save.emit(value);
    }
  }
} 