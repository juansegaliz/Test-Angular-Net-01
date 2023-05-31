import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'fro-danger-dialog',
  templateUrl: './danger-dialog.component.html',
  styleUrls: ['./danger-dialog.component.scss']
})
export class DangerDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<DangerDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}
}
