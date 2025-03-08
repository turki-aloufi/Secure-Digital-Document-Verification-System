# Document Manager

A web application for uploading, managing, and verifying documents. The frontend is built with Angular, and the backend is powered by ASP.NET Core with Entity Framework Core for database interactions. The app allows users to upload documents, view all documents with their verification status, and verify documents using unique codes.

## Features
- **Upload Documents**: Users can upload files with titles, generating a unique verification code.
- **View All Documents**: A dashboard displays all documents with details like ID, title, verification code, status, and creation date.
- **Verify Documents**: Users can verify documents by entering a verification code.
- **Responsive UI**: Styled with Bootstrap for a modern, mobile-friendly design.
- **API Integration**: Seamless communication between Angular frontend and .NET backend via RESTful APIs.

## Tech Stack
- **Frontend**: Angular 17, Bootstrap 5
- **Backend**: ASP.NET Core 6+, Entity Framework Core
- **Database**: SQL Server (via ApplicationDbContext)
- **Tools**: .NET CLI, Angular CLI, RxJS for HTTP requests

## Prerequisites
- **Node.js**: v16+ (with npm)
- **Angular CLI**: `npm install -g @angular/cli`
- **.NET SDK**: 6.0+ (install from [dotnet.microsoft.com](https://dotnet.microsoft.com/))
- **SQL Server**: LocalDB or a running instance (update connection string in `appsettings.json` if needed)

## Project Setup

### Backend Setup
1. **Navigate to Backend Directory**:
   ```
   cd backend
   ```
2. **Restore Dependencies**:
   ```
   dotnet restore
   ```
3. **Update Database** (if using EF Core migrations):
   - Ensure your connection string in `appsettings.json` is correct:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DocumentManagerDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```
   - Apply migrations:
     ```
     dotnet ef database update
     ```
4. **Run Backend**:
   ```
   dotnet run
   ```
   - API will be available at `http://localhost:5297`.

### Frontend Setup
1. **Navigate to Frontend Directory**:
   ```
   cd frontend
   ```
2. **Install Dependencies**:
   ```
   npm install
   ```
3. **Run Frontend**:
   ```
   ng serve
   ```
   - App will be available at `http://localhost:4200`.

## Usage
1. **Start Both Servers**:
   - Backend: `dotnet run` (in `backend/` folder)
   - Frontend: `ng serve` (in `frontend/` folder)
2. **Access the App**:
   - Open `http://localhost:4200` in your browser.
3. **Features**:
   - **Dashboard**: View all documents (`/dashboard`).
   - **Upload**: Upload a new document (`/upload`).
   - **Verify**: Verify a document by code (`/verify`).

## Project Structure

### Backend (`backend/`)
```
backend/
├── Controllers/
│   └── DocumentsController.cs  # API endpoints for document management
├── Entities/
│   └── Document.cs            # Document entity model
├── Models/
│   ├── DocumentDto.cs         # DTO for document responses
│   └── UploadDocumentDto.cs   # DTO for upload requests
├── Program.cs                 # Main app configuration (CORS, services)
├── appsettings.json           # Configuration (e.g., DB connection)
└── ApplicationDbContext.cs    # EF Core DbContext
```

### Frontend (`frontend/`)
```
frontend/
├── src/
│   ├── app/
│   │   ├── app.component.*    # Root component with navbar
│   │   ├── dashboard/         # Dashboard component
│   │   ├── document-upload/   # Upload component
│   │   ├── verification/      # Verify component
│   │   └── app-routing.module.ts  # Routing configuration
│   ├── assets/                # Static files (e.g., images)
│   └── styles.css             # Global styles
├── angular.json               # Angular CLI config (includes Bootstrap)
└── package.json               # Frontend dependencies
```

## API Endpoints
- **GET /api/documents**: Retrieve all documents.
- **GET /api/documents/{id}**: Retrieve a specific document by ID.
- **POST /api/documents**: Upload a new document (multipart/form-data).
- **POST /api/document/verify**: Verify a document by code (not yet implemented in provided code).

## Screenshots
*(Add screenshots here if desired, e.g., dashboard table, upload form)*

## Troubleshooting
- **CORS Issues**: Ensure `UseCors("AllowAngularApp")` is in `Program.cs` and allows `http://localhost:4200`.
- **API Not Responding**: Verify backend is running (`http://localhost:5297/api/documents`) and database is seeded.
- **Blank UI**: Check browser console (F12) for errors and ensure both servers are active.

## Future Improvements
- Add authentication (e.g., JWT) to secure endpoints and tie documents to users.
- Implement sorting and filtering on the dashboard table.
- Enhance verification with a full endpoint and status updates.
- Add file download links in the dashboard.

## Contributing
Feel free to fork this repo, submit issues, or send pull requests!

## License
This project is unlicensed—use it as you see fit!

---

### Notes
- **Directory Structure**: I assumed `backend/` and `frontend/` as folder names—adjust if your project uses different names (e.g., `DocumentManagerBackend/`).
- **Database**: The README assumes you’re using EF Core migrations. If not, update the setup steps (e.g., manual DB creation).
- **Screenshots**: You can add these by taking screenshots and placing them in a `screenshots/` folder, then linking them like `![Dashboard](screenshots/dashboard.png)`.

To use this:
1. Create a file named `README.md` in your project root.
2. Copy-paste the content above.
3. Customize as needed (e.g., project name, specific versions, additional credits).
