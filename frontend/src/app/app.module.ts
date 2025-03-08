import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DocumentUploadComponent } from './document-upload/document-upload.component';
import { VerificationComponent } from './verification/verification.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    DocumentUploadComponent,
    VerificationComponent
  ],
  imports: [
    BrowserModule,
    CommonModule, // For date pipe
    HttpClientModule, // For HTTP requests
    ReactiveFormsModule, // For forms
    AppRoutingModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}