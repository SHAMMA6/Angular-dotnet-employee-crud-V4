import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { LoadingComponent } from './components/loading/loading.component';
import { ValidationMessageComponent } from './components/validation-message/validation-message.component';
import { ToastComponent } from './components/toast/toast.component';

@NgModule({
  declarations: [
    ToolbarComponent,
    LoadingComponent,
    ValidationMessageComponent,
    ToastComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ToolbarComponent,
    LoadingComponent,
    ValidationMessageComponent,
    ToastComponent
  ]
})
export class SharedModule {} 