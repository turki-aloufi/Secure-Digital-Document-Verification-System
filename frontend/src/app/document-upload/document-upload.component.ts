import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-document-upload',
  standalone: false,
  templateUrl: './document-upload.component.html',
  styleUrls: ['./document-upload.component.css']
})
export class DocumentUploadComponent {
  uploadForm: FormGroup;
  loading = false;
  error: string | null = null;
  success: string | null = null;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.uploadForm = this.fb.group({
      title: ['', Validators.required],
      file: [null, Validators.required]
    });
  }

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      this.uploadForm.patchValue({ file: event.target.files[0] });
    }
  }

  onSubmit() {
    if (this.uploadForm.valid) {
      this.loading = true;
      this.error = null;
      this.success = null;
      const formData = new FormData();
      formData.append('title', this.uploadForm.get('title')?.value);
      formData.append('file', this.uploadForm.get('file')?.value);
      this.http.post('http://localhost:5297/api/documents', formData).subscribe({
        next: (response) => {
          this.success = 'Document uploaded successfully!';
          this.loading = false;
          this.uploadForm.reset();
        },
        error: (err) => {
          this.error = err.message;
          this.loading = false;
        }
      });
    }
  }
}