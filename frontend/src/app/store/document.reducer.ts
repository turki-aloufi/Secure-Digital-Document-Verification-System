// import { createReducer, on } from '@ngrx/store';
// import { DocumentState, AppDocument } from './document.model'; // Import AppDocument
// import * as DocumentActions from './document.actions';

// const initialState: DocumentState = {
//   documents: [],
//   loading: false,
//   error: null
// };

// export const documentReducer = createReducer(
//   initialState,
//   on(DocumentActions.loadDocuments, state => ({ ...state, loading: true })),
//   on(DocumentActions.loadDocumentsSuccess, (state, { documents }: { documents: AppDocument[] }) => ({ ...state, documents, loading: false })),
//   on(DocumentActions.loadDocumentsFailure, (state, { error }) => ({ ...state, error, loading: false })),

//   on(DocumentActions.uploadDocument, state => ({ ...state, loading: true })),
//   on(DocumentActions.uploadDocumentSuccess, (state, { document }: { document: AppDocument }) => ({
//     ...state,
//     documents: [...state.documents, document],
//     loading: false
//   })),
//   on(DocumentActions.uploadDocumentFailure, (state, { error }) => ({ ...state, error, loading: false })),

//   on(DocumentActions.verifyDocument, state => ({ ...state, loading: true })),
//   on(DocumentActions.verifyDocumentSuccess, state => ({ ...state, loading: false })),
//   on(DocumentActions.verifyDocumentFailure, (state, { error }) => ({ ...state, error, loading: false }))
// );