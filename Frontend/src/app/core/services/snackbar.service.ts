import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  private defaultDuration: number = 5000;

  constructor(private snackBar: MatSnackBar) { }

  openSuccess(message: string, action: string = '', duration: number = this.defaultDuration) {
    this.snackBar.open(message, action, {
      duration: duration,
      panelClass: ['success-snackbar']
    });
  }

  openError(message: string, action: string = '', duration: number = this.defaultDuration) {
    this.snackBar.open(message, action, {
      duration: duration,
      panelClass: ['error-snackbar']
    });
  }
}
