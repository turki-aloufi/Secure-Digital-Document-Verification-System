import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface AppDocument {
  id: number;
  title: string;
  filePath: string;
  verificationCode: string;
  status: string;
  createdAt: string;
}

@Component({
  selector: 'app-dashboard',
  standalone: false,
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  documents: AppDocument[] = [];
  loading = true;
  error: string | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadDocuments();
  }

  loadDocuments(): void {
    this.loading = true;
    this.http.get<AppDocument[]>('http://localhost:5297/api/documents').subscribe({
      next: (documents) => {
        this.documents = documents;
        this.loading = false;
      },
      error: (err) => {
        console.error('API Error:', err);
        this.error = 'Failed to load documents: ' + err.message;
        this.loading = false;
      }
    });
  }
}