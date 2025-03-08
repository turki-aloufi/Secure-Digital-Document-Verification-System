import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-verification',
  standalone: false,
  templateUrl: './verification.component.html',
  styleUrls: ['./verification.component.css']
})
export class VerificationComponent {
  verifyForm: FormGroup;
  loading = false;
  error: string | null = null;
  success: string | null = null;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.verifyForm = this.fb.group({
      verificationCode: ['', Validators.required],
      verifiedBy: [3, Validators.required],
      status: ['Verified', Validators.required]
    });
  }

  onSubmit() {
    if (this.verifyForm.valid) {
      this.loading = true;
      this.error = null;
      this.success = null;
      this.http.post('http://localhost:5297/api/document/verify', this.verifyForm.value).subscribe({
        next: (response: any) => {
          this.success = response.message || 'Document verified successfully!';
          this.loading = false;
          this.verifyForm.reset({ verifiedBy: 3, status: 'Verified' });
        },
        error: (err) => {
          this.error = err.message;
          this.loading = false;
        }
      });
    }
  }
}