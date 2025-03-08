// import { Injectable } from '@angular/core';
// import { Actions, createEffect, ofType } from '@ngrx/effects';
// import { HttpClient } from '@angular/common/http';
// import { of } from 'rxjs';
// import { catchError, map, mergeMap } from 'rxjs/operators';
// import * as DocumentActions from './document.actions';
// import { AppDocument } from './document.model'; // Update import

// @Injectable()
// export class DocumentEffects {
//   constructor(private actions$: Actions, private http: HttpClient) {}

//   loadDocuments$ = createEffect(() =>
//     this.actions$.pipe(
//       ofType(DocumentActions.loadDocuments),
//       mergeMap(() =>
//         this.http.get<AppDocument>('http://localhost:5297/api/documents/1').pipe(
//           map(document => DocumentActions.loadDocumentsSuccess({ documents: [document] })),
//           catchError(error => of(DocumentActions.loadDocumentsFailure({ error: error.message })))
//         )
//       )
//     )
//   );

//   uploadDocument$ = createEffect(() =>
//     this.actions$.pipe(
//       ofType(DocumentActions.uploadDocument),
//       mergeMap(({ formData }) =>
//         this.http.post<AppDocument>('http://localhost:5297/api/documents', formData).pipe(
//           map(document => DocumentActions.uploadDocumentSuccess({ document })),
//           catchError(error => of(DocumentActions.uploadDocumentFailure({ error: error.message })))
//         )
//       )
//     )
//   );

//   verifyDocument$ = createEffect(() =>
//     this.actions$.pipe(
//       ofType(DocumentActions.verifyDocument),
//       mergeMap(({ data }) =>
//         this.http.post<{ message: string; verificationCode: string }>('http://localhost:5297/api/document/verify', data).pipe(
//           map(response => DocumentActions.verifyDocumentSuccess({ message: response.message })),
//           catchError(error => of(DocumentActions.verifyDocumentFailure({ error: error.message })))
//         )
//       )
//     )
//   );
// }