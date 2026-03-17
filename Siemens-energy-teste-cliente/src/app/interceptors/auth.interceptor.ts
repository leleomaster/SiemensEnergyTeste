import { HttpErrorResponse, HttpInterceptorFn, HttpResponse } from '@angular/common/http';
import { catchError, tap, throwError } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { inject } from '@angular/core';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
    const authToken = 'seu-token-aqui';
    const snackBar = inject(MatSnackBar);
    const authReq = req.clone({
        setHeaders: { Authorization: `Bearer ${authToken}` }
    });
    return next(authReq).pipe(
        tap(event => {
            if (event instanceof HttpResponse) {
                console.log(`Sucesso na requisição [${req.method}] ${req.url}:`, event.status);
            }
        }),
        catchError((error: HttpErrorResponse) => {
            let errorMessage = 'Ocorreu um erro desconhecido';

            if (error.error instanceof ErrorEvent) {
                errorMessage = `Erro: ${error.error.message}`;
            } else {
                errorMessage = `Código: ${error.status} - Mensagem: ${error.message}`;
            }

            snackBar.open(errorMessage, 'Fechar', {
                duration: 5000,
                panelClass: ['error-snackbar'],
                verticalPosition: 'top'
            });

            return throwError(() => new Error(errorMessage));
        })
    );
};